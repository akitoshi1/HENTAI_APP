using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImageChoiceAndResize
{

    public partial class frmMain : Form
    {
        #region クラス

        /// <summary>
        /// 
        /// </summary>
        public class ImageFile
        {
            /// <summary>
            /// フルパス
            /// </summary>
            public string fullName = string.Empty;

            /// <summary>
            /// ファイル名
            /// </summary>
            public string name = string.Empty;

            /// <summary>
            /// 番号
            /// </summary>
            public int index = 0;

            /// <summary>
            /// 横幅
            /// </summary>
            public int intWidth = 0;

            /// <summary>
            /// 高さ
            /// </summary>
            public int intHeight = 0;

            /// <summary>
            /// イメージタイプ
            /// </summary>
            public ImageType imageType = ImageType.Unknown;

            /// <summary>
            /// リムーブフラグ
            /// </summary>
            public bool isRemove = false;

        }

        #endregion クラス

        #region 列挙・定数

        /// <summary>
        /// イメージタイプ
        /// </summary>
        public enum ImageType
        {
            Square, Portrait, Landscape, Unknown
        }

        /// <summary>
        /// システム情報
        /// </summary>
        public const string SYSTEM_INFO = "V02_[https://civitai.com/user/suteakasuteakasuteka434]";

        /// <summary>
        /// 横幅初期値 縦長
        /// </summary>
        public const string DEF_WIDTH_PORTRAIT = "832";

        /// <summary>
        /// 横幅初期値 横長
        /// </summary>
        public const string DEF_WIDTH_LANDSCAPE = "1216";

        /// <summary>
        /// 横幅初期値 正方形
        /// </summary>
        public const string DEF_WIDTH_SQUARE = "1024";

        

        #endregion 列挙・定数

        #region 変数

        /// <summary>
        /// システム引数
        /// </summary>
        public string[] ARGS;

       

        /// <summary>
        /// 表示パス
        /// </summary>
        public string lordPath = string.Empty;

        /// <summary>
        /// フォルダ名(禁則文字の除去)
        /// </summary>
        /// <returns></returns>
        public string FolderName()
        {
            DirectoryInfo di = new DirectoryInfo(this.lordPath);
            string folderName = di.Name;
            folderName = folderName.Replace(" ", "_");   //スペース
            folderName = folderName.Replace("　", "_");  //全角スペース
            folderName = folderName.Replace("-", "_");  //演算文字
            folderName = folderName.Replace("+", "_");  //演算文字
            folderName = folderName.Replace("=", "_");  //演算文字
            folderName = folderName.Replace("~", "_");  //演算文字
            folderName = folderName.Replace(".", "_");   //演算文字
            folderName = folderName.Replace("__", "_"); //ダブンアンダーバー 
            folderName = folderName.Replace("__", "_"); //ダブンアンダーバー
            folderName = folderName.Replace("__", "_"); //ダブンアンダーバー
            folderName = folderName.Replace("__", "_"); //ダブンアンダーバー
            folderName = folderName.Replace("__", "_"); //ダブンアンダーバー　...これでも残るなら知らん

            return folderName;
        }

        /// <summary>
        /// リムーブパス
        /// </summary>
        public string RemovePath()
        {
            return Path.Combine(lordPath, "ReMove");
        }

        /// <summary>
        /// パッケージパス
        /// </summary>
        /// <returns></returns>
        public string PackagePath()
        {
            string packagePath = string.Empty;
            DirectoryInfo di = new DirectoryInfo(this.lordPath);

            try
            {
                // パッケージパス名が空欄ならダメ
                if (this.txtPacageFolderName.Text == string.Empty)
                {
                    return string.Empty;
                }

                for (int i = 0; i < 100; i++)
                {
                    if (i == 0)
                    {
                        packagePath = Path.Combine(di.Parent.FullName, this.txtPacageFolderName.Text);
                    }
                    else
                    {
                        packagePath = Path.Combine(di.Parent.FullName, this.txtPacageFolderName.Text + "(" + i.ToString() + ")");
                    }
                    //重複フォルダが存在しないならOK
                    if (!Directory.Exists(packagePath))
                    {
                        break;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return packagePath;
        }

        /// <summary>
        /// 表示用画像ファイル一覧
        /// </summary>
        public List<ImageFile> listImageFiles = new List<ImageFile>();

        /// <summary>
        /// 表示用画像ファイル件数
        /// </summary>
        /// <returns></returns>
        public string ImageFilesCount()
        {
            return listImageFiles.Count.ToString();
        }

        /// <summary>
        /// リムーブフォルダのファイルカウント
        /// </summary>
        /// <returns></returns>
        public string RemoveFileCount()
        {
            if (Directory.Exists(this.RemovePath()))
            {
                return "🗑[" + Directory.EnumerateFiles(this.RemovePath(), "*", SearchOption.AllDirectories).Count().ToString() + "]";
            }
            return "";
        }

        /// <summary>
        /// 左クリック中
        /// </summary>
        public bool blnLeftClick = false;

        #endregion 変数

        #region イベント

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="args"></param>
        public frmMain(string[] args)
        {
            try
            {
                this.ARGS = args;

                //
                InitializeComponent();

                // イベント追加
                this.MouseWheel += frmMain_MouseWheel;

                // 画面表示更新
                if (!this.ChengeDir(false))
                {
                    return;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //システム情報の設定
                this.lblSystemInfo.Text = SYSTEM_INFO;

                //システムテーマの設定
                SystemTheme st = new SystemTheme();
                st.SetSystemTheme(this);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// フォームD&E
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// フォームD&D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {

            try
            {
                // 左クリック中ならなにもしない
                if (this.blnLeftClick == true)
                {
                    //一応ここで通知も解除しておく
                    this.blnLeftClick = false;
                    return;
                }

                // システム引数にセット
                this.ARGS = (string[])e.Data.GetData(DataFormats.FileDrop);

                // 画面表示更新
                if (!this.ChengeDir(false))
                {
                    return;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// マウスホイールイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                // ホイール上回転
                //前の画像表示
                this.SetBackImage();
            }
            else
            {
                // ホイール下回転
                // 次の画像表示
                this.SetNextImage();
            }
        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            //前の画像表示
            this.SetBackImage();
        }

        /// <summary>
        /// 次へボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            // 次の画像表示
            this.SetNextImage();
        }


        /// <summary>
        /// リムーブボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // リムーブフォルダに移動
            this.RemoveImage();
        }


        /// <summary>
        /// リサイズボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResize_Click(object sender, EventArgs e)
        {
            // 更新する
            if (!this.ChengeDir(true))
            {
                return;
            }

            // リサイズパネルの表示
            this.ShowResizePanel();
        }

        /// <summary>
        /// リロードボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRelord_Click(object sender, EventArgs e)
        {
            // 画面表示更新
            if (!this.ChengeDir(false))
            {
                return;
            }

        }

        /// <summary>
        /// 画像のマウスダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                // リムーブフォルダに移動
                this.RemoveImage();
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                // 左クリック中をアプリに通知
                this.blnLeftClick = true;

                // 今のインデックス
                int nowIndex = Convert.ToInt32(this.lblFileIndex.Text);
                var result = this.listImageFiles.Where(x => x.index == nowIndex);
                // 別のアプリにドラッグドロップ
                foreach (ImageFile ifile in result)
                {
                    System.IO.FileInfo fi = new FileInfo(ifile.fullName);
                    if (fi.Exists)
                    {
                        string[] files = { (string)fi.FullName };
                        DataObject dataObj = new DataObject(DataFormats.FileDrop, files);
                        DragDropEffects dde = this.pictureBox.DoDragDrop(dataObj, DragDropEffects.Copy);
                    }
                }

                // 左クリック中の通知を解除
                this.blnLeftClick = false ;


                //前の画像表示
                this.SetBackImage();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                // 次の画像表示
                this.SetNextImage();
                return;
            }


        }


        /// <summary>
        /// タグテキストのクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblShowInfo3_Click(object sender, EventArgs e)
        {
            if (this.lblShowInfo3.Text != string.Empty)
            {
                Clipboard.SetText(this.lblShowInfo3.Text);
            }
        }


        #endregion イベント

        #region メソッド

        /// <summary>
        /// フォームの初期化
        /// </summary>
        public void InitForm()
        {
            try
            {
                // 画面初期化
                this.lblShowInfo.Text = string.Empty;
                this.lblShowInfo2.Text = string.Empty;
                this.lblShowInfo3.Text = string.Empty;
                this.lblFileIndex.Text = string.Empty;
                this.lblFileName.Text = string.Empty;
                this.lblImageWidth.Text = string.Empty;
                this.lblImageHeight.Text = string.Empty;

                // ボタンツールチップ
                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                toolTip.SetToolTip(this.btnResize, "Setting [Resize and Package]");
                toolTip.SetToolTip(this.btnBack, "Back Image(Wheel Up)");
                toolTip.SetToolTip(this.btnRemove, "Remove Image(Wheel Click)");
                toolTip.SetToolTip(this.btnNext, "Next Image(Wheel Down)");
                toolTip.SetToolTip(this.btnRelord, "Relord");
                toolTip.SetToolTip(this.btnResizePack, "GO [Resize and Package]");
                toolTip.SetToolTip(this.btnCancel, "Cancel Back");
                toolTip.SetToolTip(this.lblShowInfo3, "Left click to copy tag text");

                // ボタンの有効化
                this.SetBtnEnabled(false);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 画面ボタンの有効設定
        /// </summary>
        private void SetBtnEnabled(bool enabled)
        {
            try
            {
                // ボタンの有効化
                this.btnResize.Enabled = enabled;
                this.btnBack.Enabled = enabled;
                this.btnRemove.Enabled = enabled;
                this.btnNext.Enabled = enabled;
                this.btnRelord.Enabled = enabled;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 表示対象ディレクトリの変更
        /// </summary>
        /// <returns></returns>
        public bool ChengeDir(bool isGetImageSize)
        {
            string[] imageExtensionArray = new string[] { ".BMP", ".JPG", ".JPEG", ".PNG",".GIF",".TIFF",".TIF",".ICO",".WMF",".EMF" };
            bool isImageFile = false;
            int i = 0;

            try
            {
                // フォーム初期化
                this.InitForm();

                // 引数
                foreach (string arg in this.ARGS)
                {
                    this.lordPath = this.ARGS[0];
                }

                // ディレクトリチェック
                if (Directory.Exists(this.lordPath))
                {
                    //ディレクトリが存在するなら
                    this.Text = "[" + this.ARGS[0] + "]";

                    //ドロップダウン誘導ラベルを非表示
                    this.lblFolder.Visible = false;
                    this.lblpleaseDorpDown.Visible = false;
                    this.pnlLogo.Visible = false;
                }
                else
                {
                    this.Text = "Please drop the image Folder.";
                    //MessageBox.Show("Please drop the image Folder.");
                    this.lordPath = string.Empty;

                    //ドロップダウン誘導ラベルを表示
                    this.lblFolder.Visible = true;
                    this.lblpleaseDorpDown.Visible = true;
                    this.pnlLogo.Visible = true;
                    return false;
                }

                // ファイル情報の取得
                DirectoryInfo di = new DirectoryInfo(this.lordPath);
                FileInfo[] fiArray = di.GetFiles();

                // ファイル一覧の初期化
                this.listImageFiles = new List<ImageFile>();
                foreach (FileInfo fi in fiArray)
                {
                    ImageFile ifile = new ImageFile();
                    ifile.fullName = fi.FullName;
                    ifile.name = fi.Name;

                    //プログレスバーの表示
                    this.ShowProgressBar(i, fiArray.Count()); i++;

                    // 画像ファイル判定
                    if (imageExtensionArray.Contains(fi.Extension.ToUpper()))
                    {
                        try
                        {

                            // ------------------------------------------------------
                            // --ここからが遅い 画像情報の取得を高速化すべき
                            // ------------------------------------------------------
                            if (isGetImageSize)
                            {
                                //画像情報の取得
                                Image image = Image.FromFile(ifile.fullName);
                                ifile.intWidth = image.Width;
                                ifile.intHeight = image.Height;

                                if (image.Width == image.Height)
                                {
                                    ifile.imageType = ImageType.Square;
                                }
                                else
                                {
                                    if (image.Width > image.Height)
                                    {
                                        ifile.imageType = ImageType.Landscape;
                                    }
                                    else
                                    {
                                        ifile.imageType = ImageType.Portrait;
                                    }
                                }

                                image.Dispose();
                                image = null;
                            }
                            // ------------------------------------------------------
                            // --ここまでが遅い 
                            // ------------------------------------------------------

                            this.listImageFiles.Add(ifile);

                            isImageFile = true; //画像情報が存在する
                        }
                        catch
                        {
                            // 画像情報取得のエラーは無視する
                        }
                    }
                }

                // ファイル一覧のソート（名前順）
                this.listImageFiles.Sort((a, b) => a.name.CompareTo(b.name));


                // インデックスの設定
                int indexCnt = 1;
                foreach (ImageFile ifile in this.listImageFiles)
                {
                    ifile.index = indexCnt;
                    if (indexCnt == 1)
                    {
                        this.SetImage(ifile);
                    }
                    indexCnt++;
                }


                // ボタンの有効化
                this.SetBtnEnabled(isImageFile);

                // 先頭ファイルの画像表示                
                this.SetFirstImage();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.progressBar.Visible = false; 
            }
            return true;
        }

        /// <summary>
        /// 画像表示
        /// </summary>
        public void SetImage(ImageFile ifile)
        {
            bool isRemove = false;
            try
            {
                // リソース解放
                if (this.pictureBox.Image != null)
                {
                    this.pictureBox.Image.Dispose();
                    this.pictureBox.Image = null;
                }

                // リソース再設定
                if (File.Exists(ifile.fullName))
                {
                    using (var image = Image.FromFile(ifile.fullName))
                    {

                        this.pictureBox.Image = new Bitmap(image);
                    }
                }
                else
                {
                    // リムーブ済
                    isRemove = true;
                }

                // 内部パラメータ値の設定
                this.lblFileIndex.Text = ifile.index.ToString();
                this.lblFileName.Text = "Name:" + ifile.name;
                this.lblImageWidth.Text = "Width:" + ifile.intWidth.ToString();
                this.lblImageHeight.Text = "Height:" + ifile.intHeight.ToString();

                

                if (isRemove)
                {
                    // 表示情報
                    this.lblShowInfo.Text = "[" + this.lblFileIndex.Text + "]_[🗑️ REMOVED 🗑️]";
                    
                }
                else
                {
                    // 表示情報
                    //this.lblShowInfo.Text = "[" + this.lblFileIndex.Text + "]_[" + this.lblFileName.Text + "]_[" + this.lblImageWidth.Text + "]_[" + this.lblImageHeight.Text + "]";
                    this.lblShowInfo.Text = "[" + this.lblFileIndex.Text + "]_[" + this.lblFileName.Text + "]";
                    
                }
                this.lblShowInfo2.Text = "[" + this.lblFileIndex.Text + "/" + this.ImageFilesCount() + "] " + this.RemoveFileCount();

                //タグテキストが存在するなら、ラベル3に表示
                string tagTextFileName = Path.ChangeExtension(ifile.fullName, ".txt");
                if(File.Exists(tagTextFileName))
                {
                    this.lblShowInfo3.Text = File.ReadAllText(tagTextFileName, Encoding.UTF8);
                    
                }
                else
                {
                    this.lblShowInfo3.Text = string.Empty;
                    
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 最初の画像表示
        /// </summary>
        public void SetFirstImage()
        {
            try
            {
                var result = this.listImageFiles.Where(x => x.index == 1);
                foreach (ImageFile ifile in result)
                {
                    this.SetImage(ifile);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 次の画像表示
        /// </summary>
        public void SetNextImage()
        {
            try
            {
                // インデックスが空白なら終了
                if (this.lblFileIndex.Text == string.Empty)
                {
                    return;
                }

                // リムーブボタンが非活性なら終了
                if (this.btnRemove.Enabled == false)
                {
                    return;
                }

                // 次のインデックス
                int nextIndex = Convert.ToInt32(this.lblFileIndex.Text) + 1;

                var result = this.listImageFiles.Where(x => x.index == nextIndex);
                foreach (ImageFile ifile in result)
                {
                    this.SetImage(ifile);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 前の画像表示
        /// </summary>
        public void SetBackImage()
        {
            try
            {
                // インデックスが空白なら終了
                if (this.lblFileIndex.Text == string.Empty)
                {
                    return;
                }

                // リムーブボタンが非活性なら終了
                if (this.btnRemove.Enabled == false)
                {
                    return;
                }

                // 前のインデックス
                int backIndex = Convert.ToInt32(this.lblFileIndex.Text) - 1;

                var result = this.listImageFiles.Where(x => x.index == backIndex);
                foreach (ImageFile ifile in result)
                {
                    this.SetImage(ifile);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// リムーブイメージ
        /// </summary>
        public void RemoveImage()
        {
            string sorcePath = string.Empty;
            string removePath = string.Empty;
            try
            {
                // インデックスが空白なら終了
                if (this.lblFileIndex.Text == string.Empty)
                {
                    return;
                }

                // リムーブボタンが非活性なら終了
                if(this.btnRemove .Enabled == false )
                {
                    return;
                }

                // リムーブパスが存在しないなら作成
                if (!Directory.Exists(this.RemovePath()))
                {
                    Directory.CreateDirectory(this.RemovePath());
                }

                // PictuerBoxの解放
                if (this.pictureBox.Image != null)
                {
                    this.pictureBox.Image.Dispose();
                    this.pictureBox.Image = null;
                }

                // 現在のインデックス
                int nowIndex = Convert.ToInt32(this.lblFileIndex.Text);         // 現在のインデックス                

                // 現在の画像の移動情報を設定
                var result = this.listImageFiles.Where(x => x.index == nowIndex);
                foreach (ImageFile ifile in result)
                {
                    if (ifile.isRemove != true)
                    {
                        sorcePath = Path.Combine(this.lordPath, ifile.name);
                        removePath = Path.Combine(this.RemovePath(), ifile.name);
                        ifile.isRemove = true;
                    }
                }

                // 物理移動
                if (removePath != string.Empty)
                {
                    FileInfo fi = new FileInfo(sorcePath);
                    fi.MoveTo(removePath);
                }

                //　次の画像を表示
                this.SetNextImage();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        #endregion メソッド

        #region リサイズパネル
        /// <summary>
        /// リサイズパネルの表示
        /// </summary>
        public void ShowResizePanel()
        {
            try
            {

                this.pnlResize.Visible = true;
                this.pictureBox.Visible = false;

                this.btnResize.Enabled = false;
                this.btnBack.Enabled = false;
                this.btnRemove.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnRelord.Enabled = false;

                this.txtLandscapeWidth.Text = DEF_WIDTH_LANDSCAPE;
                this.txtPortraitWidth.Text = DEF_WIDTH_PORTRAIT;
                this.txtSquareWidth.Text = DEF_WIDTH_SQUARE;

                //リサイズ設定のチェック
                int sumPortrait = this.listImageFiles.Count(x => x.imageType == ImageType.Portrait);
                int sumSquare = this.listImageFiles.Count(x => x.imageType == ImageType.Square);
                int sumLandscape = this.listImageFiles.Count(x => x.imageType == ImageType.Landscape);
                this.SetResize(sumPortrait, this.chkPortrait, this.txtPortraitWidth, this.txtPortraitCount);
                this.SetResize(sumSquare, this.chkSquare, this.txtSquareWidth, this.txtSquareCount);
                this.SetResize(sumLandscape, this.chkLandscape, this.txtLandscapeWidth, this.txtLandscapeCount);

                //インフォメーションの表示
                this.lblShowInfo.Text = string.Empty;
                this.lblShowInfo2.Text = string.Empty; 
                this.lblShowInfo3.Text = string.Empty;


                //先頭数値
                if (sumPortrait + sumSquare + sumLandscape > 100)
                {
                    this.txtPackageName_Head.Text = "1";
                }
                else if (sumPortrait + sumSquare + sumLandscape > 50)
                {
                    this.txtPackageName_Head.Text = "5";
                }
                else
                {
                    this.txtPackageName_Head.Text = "10";
                }

                //名前 禁則文字を除去したフォルダ名
                this.txtPackageName_Name.Text = this.FolderName();

                //バージョン
                this.txtPackageName_Version.Text = "V01";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// リサイズ項目のセット
        /// </summary>
        private void SetResize(int point, CheckBox chkBox, System.Windows.Forms.TextBox txtWidth, System.Windows.Forms.TextBox txtCount)
        {
            try
            {
                txtCount.Text = point.ToString();
                if (point > 0)
                {
                    chkBox.Enabled = true;
                    chkBox.Checked = true;
                    txtWidth.Enabled = true;
                }
                else
                {
                    chkBox.Enabled = false;
                    chkBox.Checked = false;
                    txtWidth.Enabled = false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// リサイズパネルのクローズ
        /// </summary>
        public void CloseResizePanel()
        {
            try
            {
                this.pnlResize.Visible = false;
                this.pictureBox.Visible = true;

                this.btnResize.Enabled = true;
                this.btnBack.Enabled = true;
                this.btnRemove.Enabled = true;
                this.btnNext.Enabled = true;
                this.btnRelord.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// パッケージ ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResizePack_Click(object sender, EventArgs e)
        {
            int i = 0;  //カウンタ
            try
            {
                // パッケージパスの取得
                string outDirectoryPath = this.PackagePath();
                if (!Directory.Exists(outDirectoryPath))
                {
                    Directory.CreateDirectory(outDirectoryPath);
                }

                // 画像ファイルのリサイズ
                foreach (ImageFile ifile in this.listImageFiles)
                {
                    //プログレスバーの表示
                    this.ShowProgressBar(i, this.listImageFiles.Count); i++;

                    // リサイズ対象判定
                    if (this.isResize(ifile))
                    {

                        // リサイズ元のパス
                        string inputPath = ifile.fullName;

                        // リサイズファイル名
                        string resizeFileName = this.GetResizeFileName(ifile);

                        // リサイズ先のパス
                        string outputPath = Path.Combine(outDirectoryPath, resizeFileName);

                        // 画像ファイルのリサイズ
                        ResizeImage ri = new ResizeImage();
                        ri.Resize(inputPath, outputPath, this.GetWidthPont(ifile), this.GetResizeImageFormat());
                    }
                }


                //出力パッケージのオートリロード
                if(this.chkAutoRelord.Checked  )
                {
                    // システム引数にパッケージのパスを設定
                    this.ARGS[0] = outDirectoryPath;

                    // 画面表示更新
                    if (!this.ChengeDir(false))
                    {
                        return;
                    }

                    //完了メッセージの表示
                    MessageBox.Show("Relord Output Pacage" + Environment.NewLine + Environment.NewLine + outDirectoryPath);
                }
                else
                {
                    //完了メッセージの表示
                    MessageBox.Show("Output Pacage" + Environment.NewLine + Environment.NewLine + outDirectoryPath);
                }


                //リサイズパネルを閉じる
                this.CloseResizePanel();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.progressBar.Visible = false; 
            }
        }

        /// <summary>
        /// リサイズの対象取得
        /// </summary>
        /// <param name="ifile"></param>
        /// <returns></returns>
        private bool isResize(ImageFile ifile)
        {
            try
            {


                // 不明
                if (ifile.imageType == ImageType.Unknown)
                {
                    return false;
                }

                // 正方形
                if (ifile.imageType == ImageType.Square)
                {
                    if (this.chkSquare.Checked)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                // 縦長
                if (ifile.imageType == ImageType.Portrait)
                {
                    if (this.chkPortrait.Checked)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                // 横長
                if (ifile.imageType == ImageType.Landscape)
                {
                    if (this.chkLandscape.Checked)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false ;
        }

        /// <summary>
        /// リサイズファイル名の取得
        /// </summary>
        /// <returns></returns>
        private string GetResizeFileName(ImageFile ifile)
        {
            // リサイズファイル名
            string resizeFileName = string.Empty;

            // リサイズファイルの拡張子
            string resizeFileExtension = string.Empty;

            try
            {
                // ファイル名（拡張子なし）
                if (this.chkRenameFile.Checked)
                {
                    resizeFileName = ifile.index.ToString("D5");    //0000N
                }
                else
                {
                    resizeFileName = Path.GetFileNameWithoutExtension(ifile.name);  // Name.Jpg ⇒ Name
                }

                // リサイズファイル拡張子
                if (this.rdoJpg90.Checked)
                {
                    resizeFileExtension = ".jpg";
                }
                if (this.rdoPng.Checked)
                {
                    resizeFileExtension = ".png";
                }
                if (this.rdoWEBP.Checked)
                {
                    resizeFileExtension = ".webp";
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resizeFileName + resizeFileExtension;
        }

        /// <summary>
        /// リサイズフォーマットの取得
        /// </summary>
        /// <returns></returns>
        private ImageFormat GetResizeImageFormat()
        {

            try
            {
                if (this.rdoJpg90.Checked)
                {
                    return ImageFormat.Jpeg;
                }
                if (this.rdoPng.Checked)
                {
                    return ImageFormat.Png;
                }
                if (this.rdoWEBP.Checked)
                {
                    //WEBP代用選択
                    return ImageFormat.Wmf;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ImageFormat.Jpeg;
        }



        /// <summary>
        /// 横幅のポイント取得
        /// </summary>
        /// <param name="ifile"></param>
        /// <returns></returns>
        private int GetWidthPont(ImageFile ifile)
        {
            int widthPoint = 0;

            try
            {

                // 正方形
                if (ifile.imageType == ImageType.Square)
                {
                    widthPoint = Convert.ToInt32(this.txtSquareWidth.Text);
                }
                // 縦長
                if (ifile.imageType == ImageType.Portrait)
                {
                    widthPoint = Convert.ToInt32(this.txtPortraitWidth.Text);

                }
                // 横長
                if (ifile.imageType == ImageType.Landscape)
                {
                    widthPoint = Convert.ToInt32(this.txtLandscapeWidth.Text);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return widthPoint;
        }

        /// <summary>
        /// キャンンセル ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

            //リサイズパネルを閉じる
            this.CloseResizePanel();
        }

        /// <summary>
        /// パッケージ名．先頭数字の変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPackageName_Head_TextChanged(object sender, EventArgs e)
        {
            this.JoitPackageName();
        }

        /// <summary>
        /// パッケージ名．名前の変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPackageName_Name_TextChanged(object sender, EventArgs e)
        {
            this.JoitPackageName();
        }

        /// <summary>
        /// パッケージ名．タイプの変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPackageName_type_TextChanged(object sender, EventArgs e)
        {
            this.JoitPackageName();
        }


        /// <summary>
        /// パッケージ名．モデルの変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPackageName_model_TextChanged(object sender, EventArgs e)
        {
            this.JoitPackageName();
        }


        /// <summary>
        /// パッケージ名．バージョンの変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPackageName_Version_TextChanged(object sender, EventArgs e)
        {
            this.JoitPackageName();
        }


        /// <summary>
        /// パッケージネームの更新
        /// </summary>
        public void JoitPackageName()
        {
            string packageName = string.Empty;

            try
            {

                if (this.txtPackageName_Head.Text != string.Empty)
                {
                    packageName += txtPackageName_Head.Text.Trim();
                }

                if (this.txtPackageName_Name.Text != string.Empty)
                {
                    packageName += "_" + txtPackageName_Name.Text.Trim();
                }

                if (this.txtPackageName_type.Text != string.Empty)
                {
                    packageName += "_" + txtPackageName_type.Text.Trim();
                }

                if (this.txtPackageName_model.Text != string.Empty)
                {
                    packageName += "_" + txtPackageName_model.Text.Trim();
                }

                if (this.txtPackageName_Version.Text != string.Empty)
                {
                    packageName += "_" + txtPackageName_Version.Text.Trim();
                }

                packageName = packageName.Trim();
                this.txtPacageFolderName.Text = packageName;

                if (packageName == string.Empty)
                {
                    this.btnResizePack.Enabled = false;
                }
                else
                {
                    this.btnResizePack.Enabled = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 縦長
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPortraitWidth_Validated(object sender, EventArgs e)
        {
            try
            {
                //値チェック
                var a = Convert.ToInt32(this.txtPortraitWidth.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPortraitWidth.Text = DEF_WIDTH_PORTRAIT;
            }
        }

        /// <summary>
        /// 正方形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSquareWidth_Validated(object sender, EventArgs e)
        {
            try
            {
                //値チェック
                var a = Convert.ToInt32(this.txtSquareWidth.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSquareWidth.Text = DEF_WIDTH_SQUARE;
            }

        }

        /// <summary>
        /// 横長
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLandscapeWidth_Validated(object sender, EventArgs e)
        {
            try
            {
                //値チェック
                var a = Convert.ToInt32(this.txtLandscapeWidth.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtLandscapeWidth.Text = DEF_WIDTH_SQUARE;
            }

        }


        /// <summary>
        /// JPEG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoJpg90_CheckedChanged(object sender, EventArgs e)
        {
            this.SetChkRenameFileText();
        }

        /// <summary>
        /// PNG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoPng_CheckedChanged(object sender, EventArgs e)
        {
            this.SetChkRenameFileText();
        }

        /// <summary>
        /// WEBP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoWEBP_CheckedChanged(object sender, EventArgs e)
        {
            this.SetChkRenameFileText();
        }

        /// <summary>
        /// リネームファイルチェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkRenameFile_CheckedChanged(object sender, EventArgs e)
        {
            this.SetChkRenameFileText();
        }


        /// <summary>
        /// リネームファイルチェックボックスの表示値を変更
        /// </summary>
        private void SetChkRenameFileText()        
        {
            try
            {
                string resizeFileName = string.Empty; 
                string resizeFileExtension = string.Empty;

                // リサイズファイル拡張子
                if (this.rdoJpg90.Checked)
                {
                    resizeFileExtension = ".jpg";
                }
                if (this.rdoPng.Checked)
                {
                    resizeFileExtension = ".png";
                }
                if (this.rdoWEBP.Checked)
                {
                    resizeFileExtension = ".webp";
                }

                // リサイズファイル名
                if (this.chkRenameFile.Checked )
                {
                    resizeFileName = "ReName File : 000001";
                }
                else
                {
                    resizeFileName = "ReName File : Original_File_Name";
                }

                this.chkRenameFile.Text = resizeFileName + resizeFileExtension;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }


        /// <summary>
        /// 縦長
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPortrait_CheckedChanged(object sender, EventArgs e)
        {
            this.SetBtnResizePack_Enable();
        }

        /// <summary>
        /// 正方形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSquare_CheckedChanged(object sender, EventArgs e)
        {
            this.SetBtnResizePack_Enable();
        }

        /// <summary>
        /// 横長
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkLandscape_CheckedChanged(object sender, EventArgs e)
        {
            this.SetBtnResizePack_Enable();
        }

        /// <summary>
        /// 縦長・正方形・横長関係の画面制御
        /// </summary>
        private void SetBtnResizePack_Enable()
        {
            int targetCount = 0;
            try
            {
                if (this.chkPortrait.Checked)
                {
                    this.txtPortraitWidth.Enabled = true;
                    targetCount += Convert.ToInt32(this.txtPortraitCount.Text);
                }
                else
                {
                    this.txtPortraitWidth.Enabled = false;
                }

                if (this.chkLandscape.Checked)
                {
                    this.txtLandscapeWidth.Enabled = true;
                    targetCount += Convert.ToInt32(this.txtLandscapeCount.Text);
                }
                else
                {
                    this.txtLandscapeWidth.Enabled = false;
                }

                if (this.chkSquare.Checked)
                {
                    this.txtSquareWidth.Enabled = true;
                    targetCount += Convert.ToInt32(this.txtSquareCount.Text);
                }
                else
                {
                    this.txtSquareWidth.Enabled = false;
                }

                // 実行ボタンの有効判定
                if (targetCount == 0)
                {
                    this.btnResizePack.Enabled = false;
                }
                else
                {
                    this.btnResizePack.Enabled = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion リサイズパネル

        #region プログレスバー

        /// <summary>
        /// プログレスバーの表示
        /// </summary>
        /// <param name="nowValue"></param>
        /// <param name="maxValue"></param>
        private void ShowProgressBar(int setValue, int maximum)
        {
            try
            {
                if (setValue % 10 != 0)
                {
                    return;
                }

                this.progressBar.Visible = true;
                this.progressBar.Maximum = maximum;
                this.progressBar.Value = setValue;

                double percent = 0;
                if(setValue != 0)
                {
                    percent = (double)setValue / maximum * 100;
                }

                this.lblShowInfo.Text = $"Please Wait ...Now {percent:F2} %";
                this.lblShowInfo2.Text = "[" + setValue.ToString() + "/" + maximum.ToString() + "]"   ;
                this.lblShowInfo3.Text = string.Empty;

                Application.DoEvents(); //UI更新  
                this.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion プログレスバー

        private void lblFolder_Click(object sender, EventArgs e)
        {

        }

    }
}
