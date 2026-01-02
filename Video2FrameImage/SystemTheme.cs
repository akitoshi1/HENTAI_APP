using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Civitai_Love
{
    /// <summary>
    /// クラス：Theme
    /// </summary>
    public class Theme
    {
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
    }

    /// <summary>
    /// クラス：SystemTheme
    /// </summary>
    public class SystemTheme
    {
        ///// <summary>
        ///// テーマ：ライト
        ///// </summary>
        ///// <returns></returns>
        //private Theme Light()
        //{
        //    Theme t = new Theme();
        //    t.BackColor = Color.White;
        //    t.ForeColor = Color.Black;
        //    return t;
        //}

        /// <summary>
        /// テーマ：ダーク
        /// </summary>
        /// <returns></returns>
        private Theme Dark()
        {
            Theme t = new Theme();
            t.BackColor = Color.FromArgb(32, 32, 32);
            t.ForeColor = Color.White;
            return t;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        public void SetSystemTheme(Control parent)
        {
            try
            {
                if (this.IsWindowsDarkMode())
                {
                    this.ApplyTheme(parent, this.Dark());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// コントロールのテーマ適用（ボタンとテキストは除く）
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="theme"></param>
        private void ApplyTheme(Control parent, Theme theme)
        {
            try
            {
                if (parent.Name.Substring(0, 3) != "btn")
                {
                    if (parent.Name.Substring(0, 3) != "txt")
                    {
                        parent.BackColor = theme.BackColor;
                        parent.ForeColor = theme.ForeColor;
                    }
                }
                else
                {
                    parent.BackColor = SystemColors.Control;
                    parent.ForeColor = SystemColors.ControlText;

                }

                foreach (Control c in parent.Controls)
                {
                    ApplyTheme(c, theme);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ユーザープロファイルのダークモードを取得
        /// </summary>
        /// <returns></returns>
        private bool IsWindowsDarkMode()
        {
            const string key = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            try
            {
                using (var reg = Registry.CurrentUser.OpenSubKey(key))
                {
                    if ((int)reg.GetValue("AppsUseLightTheme", 1) == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                //失敗したら諦める
            }
            return false;
        }
    }

}
