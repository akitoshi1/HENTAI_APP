using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Civitai_Love
{

    public partial class frmMain : Form
    {

        #region クラス

        /// <summary>
        /// システム設定（シリアライズ-デシリアライズ対象)
        /// </summary>

        public class SystemSetting
        {

            /// <summary>
            /// 出力ディレクトリ
            /// </summary>
            public string OutputDirectory { get; set; }
        }


        /// <summary>
        /// 
        /// </summary>
        public class VideoFile
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
            /// コーデック
            /// </summary>
            public string codec = string.Empty;


            /// <summary>
            /// （文字）FPS
            /// </summary>
            public string fps = string.Empty;

            /// <summary>
            /// （数値）FPG
            /// </summary>
            public double doubleFPS = 0;

            /// <summary>
            /// 
            /// </summary>
            public string duration = string.Empty;

            /// <summary>
            /// 
            /// </summary>
            public JsonElement format = new JsonElement();

            /// <summary>
            /// フレーム総数
            /// </summary>
            public int intTotalFrameCount = 0;

            /// <summary>
            /// フレーム出力した回数
            /// </summary>
            public int intoutPutCount = 0;
        }

        #endregion クラス

        #region 列挙・定数
        /// <summary>
        /// システム名
        /// </summary>
        public const string SYSTEM_NAME = "Video2FrameImage";

        /// <summary>
        /// システム設定シリアライズファイル名
        /// </summary>
        public const string SYSTEM_FILE_NAME = "seting.xml";

        /// <summary>
        /// システム情報
        /// </summary>
        public const string SYSTEM_INFO = "V01_[https://civitai.com/user/suteakasuteakasuteka434]";

        /// <summary>
        /// 次のアプリ名
        /// </summary>
        public const string NEXT_APP = "ImageChoice2Resize.exe";

        /// <summary>
        /// 処理選択 
        /// </summary>
        public enum StartEnd
        {
            Start, End
        }

        /// <summary>
        /// 回転処理 R1:時計回り90度　L2:反時計回り90度
        /// </summary>
        public enum Transpose
        {
            R1,L2
        }

        #endregion 列挙・定数

        #region 変数

        /// <summary>
        /// システム引数
        /// </summary>
        public string[] ARGS;


        /// <summary>
        /// 読込パス
        /// </summary>
        public string lordPath = string.Empty;

        /// <summary>
        /// 読み込んだビデオファイル
        /// </summary>
        public VideoFile videoFile = new VideoFile();


        /// <summary>
        /// システム設定情報
        /// </summary>
        public SystemSetting systemSetting = new SystemSetting();


        /// <summary>
        /// システム設定値のフォルダ
        /// </summary>
        /// <returns></returns>
        public static string SerializeSystemFolder()
        {
            string serializeSystemFolder = string.Empty;

            serializeSystemFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            serializeSystemFolder = System.IO.Path.Combine(serializeSystemFolder, SYSTEM_NAME);

            return serializeSystemFolder;
        }

        /// <summary>
        /// システム設定値のファイルパス
        /// </summary>
        /// <returns></returns>
        public static string SerializeSystemFilePath()
        {
            string serializeSystemFilePath = string.Empty;
            try
            {
                // システムフォルダが存在しないなら作成する
                if (!System.IO.Directory.Exists(SerializeSystemFolder()))
                {
                    System.IO.Directory.CreateDirectory(SerializeSystemFolder());
                }

                serializeSystemFilePath = System.IO.Path.Combine(SerializeSystemFolder(), SYSTEM_FILE_NAME);
            }
            catch (Exception err)
            {
                throw err;
            }
            return serializeSystemFilePath;
        }

        /// <summary>
        /// 出力フォルダの取得
        /// </summary>
        /// <returns></returns>
        public string GetOutputPath()
        {
            string outputPath = string.Empty;
            try
            {
                //ビデオファイルは読込済か？
                if (this.videoFile.name == string.Empty)
                {
                    return string.Empty;
                }
                else
                {
                    //システム設定-出力先フォルダがあるか？
                    if (this.systemSetting.OutputDirectory != null)
                    {
                        // 出力フォルダ+動画ファイル名（拡張子なし）
                        outputPath = Path.Combine(this.systemSetting.OutputDirectory, Path.GetFileNameWithoutExtension(this.videoFile.fullName));
                    }
                    else
                    {
                        // 動画の配置場所+動画ファイル名（拡張子なし）
                        outputPath = Path.Combine(Path.GetDirectoryName(this.videoFile.fullName), Path.GetFileNameWithoutExtension(this.videoFile.fullName));
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return outputPath;
        }

        /// <summary>
        /// 次のアプリのパス
        /// </summary>
        /// <returns></returns>
        public string GetNextAppPath()
        {
            string nextAppPath = string.Empty;
            try
            {
                nextAppPath = Path.Combine(AppContext.BaseDirectory, NEXT_APP);
            }
            catch (Exception err)
            {
                throw err;
            }
            return nextAppPath;
        }
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

                // ビデオファイルの設定
                this.SetVideoFile();


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

                //システム情報のデシリアライズ
                this.DeserializeClass();

                //画面オブジェクトの初期設定
                lblShowInfo.Text = string.Empty;
                lblShowInfo2.Text = string.Empty;
                lblShowInfo3.Text = string.Empty;

                // ボタンツールチップ
                ToolTip toolTip = new ToolTip();
                
                toolTip.SetToolTip(this.btnSystemOutput , "Select Flame Image Output Folder");  //出力先選択
                toolTip.SetToolTip(this.btnSystemSettingClose , "System Setting End");          //システム設定終了
                toolTip.SetToolTip(this.btnTEST_FFMPEG , "Video 2 FrameImage Files");           //フレーム画像の出力
                toolTip.SetToolTip(this.btnSend_Packer, "Go 2 Next Work!!");                    //次の処理へ
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
            //読込パスを初期化
            this.lordPath = string.Empty;
            try
            {

                // システム引数にセット
                this.ARGS = (string[])e.Data.GetData(DataFormats.FileDrop);

                // ビデオファイルの設定
                this.SetVideoFile();

                //// 読込パスを取得
                //foreach (string args in this.ARGS)
                //{
                //    if (File.Exists(args))
                //    {
                //        this.lordPath = args;
                //        break;
                //    }
                //}

                ////
                //if (this.lordPath == string.Empty)
                //{
                //    return;
                //}
                //else
                //{


                //    // 読込ビデオの更新
                //    this.videoFile = new VideoFile();
                //    this.videoFile.fullName = this.lordPath;
                //    this.videoFile.name = Path.GetFileName(this.lordPath);


                //    var info = FFmpegIO.GetVideoInfo(this.lordPath);
                //    var root = info.RootElement;


                //    // 最初の video stream を取得
                //    this.ShowProgressBar(1, 3);
                //    var videoStream = root
                //        .GetProperty("streams")
                //        .EnumerateArray()
                //        .First(s => s.GetProperty("codec_type").GetString() == "video");

                //    this.videoFile.codec = videoStream.GetProperty("codec_name").GetString();
                //    this.videoFile.intWidth = videoStream.GetProperty("width").GetInt32();
                //    this.videoFile.intHeight = videoStream.GetProperty("height").GetInt32();
                //    this.videoFile.fps = videoStream.GetProperty("r_frame_rate").GetString();

                //    // 数値のFPSを求める
                //    string[] fpsRateSplit = this.videoFile.fps.Split('/');
                //    try
                //    {
                //        this.videoFile.doubleFPS = Math.Round(Convert.ToDouble(fpsRateSplit[0]) / Convert.ToDouble(fpsRateSplit[1]), 2);    //小数点2桁に
                //    }
                //    catch
                //    {
                //        this.videoFile.doubleFPS = Math.Round(Convert.ToDouble(fpsRateSplit[1]), 2);    //小数点2桁に
                //    }

                //    // format 情報
                //    this.ShowProgressBar(2, 3);
                //    this.videoFile.format = root.GetProperty("format");

                //    // ビデオ編集パネルの表示
                //    this.ShowProgressBar(3, 3);
                //    this.Show_pnlEditVideo();

                //    // 既に出力済みかチェック
                //    if (Directory.Exists(this.GetOutputPath()))
                //    {
                //        //既に出力済み
                //        MessageBox.Show("It has already been output.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //        //出力済み回数を求める
                //        this.GetOutputPath_CutOutCount();

                //        // 次の作業グループボックスを表示する
                //        this.SetGroupBoxNext();
                //    }
                //    else
                //    {
                //        // 次の作業グループボックスを非表示する
                //        this.groupBoxNext.Visible = false; 

                //    }

                //}



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
        /// マウスホイールイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                // ホイール上回転
            }
            else
            {
                // ホイール下回転
            }
        }



        /// <summary>
        /// トリム開始-値変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_TrimStart_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.trackBar_TrimStart.Value >= this.trackBar_TrimEnd.Value)
                {
                    this.trackBar_TrimStart.Value = this.trackBar_TrimEnd.Value - 1;
                }
                this.txtTrimStart.Text = this.trackBar_TrimStart.Value.ToString();

                this.lblTrimStartTime.Text = this.GetDurationString(Convert.ToInt64(this.txtTrimStart.Text));
                this.txtFrameCount.Text = Convert.ToString(Convert.ToInt64(this.txtTrimEnd.Text) - Convert.ToInt64(this.txtTrimStart.Text));


                //画像表示
                this.ShowFrame(StartEnd.Start);

                //フレーム画像取得件数の更新
                this.SetlblTotalFrameImageCout();


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// トリム終了-値変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_TrimEnd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.trackBar_TrimStart.Value >= this.trackBar_TrimEnd.Value)
                {
                    this.trackBar_TrimEnd.Value = this.trackBar_TrimStart.Value + 1;
                }
                this.txtTrimEnd.Text = this.trackBar_TrimEnd.Value.ToString();

                this.lblTrimEndTime.Text = this.GetDurationString(Convert.ToInt64(this.txtTrimEnd.Text));

                if (this.txtTrimStart.Text != string.Empty)
                {
                    this.txtFrameCount.Text = Convert.ToString(Convert.ToInt64(this.txtTrimEnd.Text) - Convert.ToInt64(this.txtTrimStart.Text));
                }

                //画像表示
                this.ShowFrame(StartEnd.End);

                //フレーム画像取得件数の更新
                this.SetlblTotalFrameImageCout();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// トリム開始-値変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_TrimStart_Leave(object sender, EventArgs e)
        {
            ////画像表示
            //this.ShowFrame(StartEnd.Start);
        }


        /// <summary>
        /// トリム終了-値変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_TrimEnd_Leave(object sender, EventArgs e)
        {
            ////画像表示
            //this.ShowFrame(StartEnd.End);
        }


        /// <summary>
        /// フレーム間隔の変更確定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFrameInterval_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt16(this.cmbFrameInterval.Text);
            }
            catch
            {
                //エラーが起きたら強制的に30を設定
                this.cmbFrameInterval.Text = "30";
            }
            this.btnEm.Text = "-" + this.cmbFrameInterval.Text;
            this.btnEp.Text = "+" + this.cmbFrameInterval.Text;
            this.btnSm.Text = "-" + this.cmbFrameInterval.Text;
            this.btnSp.Text = "+" + this.cmbFrameInterval.Text;

            //フレーム画像取得件数の更新
            this.SetlblTotalFrameImageCout();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSm30_Click(object sender, EventArgs e)
        {
            try
            {
                int valueI = Convert.ToInt16(this.cmbFrameInterval.Text);
                int valutTB = this.trackBar_TrimStart.Value - valueI;

                if(valutTB  > this.trackBar_TrimStart.Minimum)
                {
                    this.trackBar_TrimStart.Value = valutTB;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSp30_Click(object sender, EventArgs e)
        {

            try
            {
                int valueI = Convert.ToInt16(this.cmbFrameInterval.Text);
                int valutTB = this.trackBar_TrimStart.Value + valueI;

                if (valutTB < this.trackBar_TrimStart.Maximum)
                {
                    this.trackBar_TrimStart.Value = valutTB;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEm30_Click(object sender, EventArgs e)
        {

            try
            {
                int valueI = Convert.ToInt16(this.cmbFrameInterval.Text);
                int valutTB = this.trackBar_TrimEnd.Value - valueI;

                if (valutTB > this.trackBar_TrimEnd.Minimum)
                {
                    this.trackBar_TrimEnd.Value = valutTB;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEp30_Click(object sender, EventArgs e)
        {

            try
            {
                int valueI = Convert.ToInt16(this.cmbFrameInterval.Text);
                int valutTB = this.trackBar_TrimEnd.Value + valueI;

                if (valutTB < this.trackBar_TrimEnd.Maximum)
                {
                    this.trackBar_TrimEnd.Value = valutTB;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 回転出力設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIsTranspose_CheckedChanged(object sender, EventArgs e)
        {
            // ラジオボタンの設定
            if (this.chkIsTranspose.Checked)
            {
                this.rdoTranspose1.Checked = true;
                this.rdoTranspose2.Checked = false;
                this.rdoTranspose1.Visible = true;
                this.rdoTranspose2.Visible = true;
                this.pnlTranspose1.Visible = true;
                this.pnlTranspose2.Visible = true;

            }
            else
            {
                this.rdoTranspose1.Visible = false;
                this.rdoTranspose2.Visible = false;
                this.pnlTranspose1.Visible = false;
                this.pnlTranspose2.Visible = false;
            }

            // 画面表示の更新            
            this.ShowFrame(StartEnd.Start);
            this.ShowFrame(StartEnd.End);
        }


        /// <summary>
        /// 回転設定 変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoTranspose1_CheckedChanged(object sender, EventArgs e)
        {
            // 画面表示の更新            
            this.ShowFrame(StartEnd.Start);
            this.ShowFrame(StartEnd.End);
        }

        /// <summary>
        /// 回転設定　変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoTranspose2_CheckedChanged(object sender, EventArgs e)
        {
            // 画面表示の更新            
            this.ShowFrame(StartEnd.Start);
            this.ShowFrame(StartEnd.End);
        }

        /// <summary>
        /// フレームイメージを次のアプリに渡す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Packer_Click(object sender, EventArgs e)
        {

            try
            {
                //次のアプリを開く
                Process.Start(this.GetNextAppPath(), this.GetOutputPath());

                if (chkCloseMe.Checked)
                {
                    this.Close();
                    // bye bye 
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion イベント


        #region メニューイベント

        /// <summary>
        /// システムメニュー-セッティング
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //メインフォームの表示設定
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Width = 700;
            this.Height = 300;

            //システム設定値を表示
            this.txtSystemOutput.Text = this.systemSetting.OutputDirectory;

            this.pnlSystemSeting.Top = 58;
            this.pnlSystemSeting.Left = 12;
            this.pnlSystemSeting.Visible = true;
            this.pnlSystemSeting.Focus();

            this.pnlEditVideo.Visible = false;

        }


        /// <summary>
        /// フォルダを開くボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSystemOutput_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            dialog.Description = "フォルダを選択してください";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtSystemOutput.Text = dialog.SelectedPath;
                this.systemSetting.OutputDirectory = this.txtSystemOutput.Text;
            }
        }


        /// <summary>
        /// システムメニュー-セッティングを閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSystemSettingClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnlSystemSeting.Visible = false;
                this.pnlEditVideo.Visible = true;

                //システム設定の更新
                this.systemSetting.OutputDirectory = this.txtSystemOutput.Text;

                //システム情報をシリアライズ
                this.SerializeClass();

                this.Width = 1030;
                this.Height = 750;

                

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion メニューイベント

        #region メソッド

        /// <summary>
        /// システム情報をシリアライズ
        /// </summary>
        private void SerializeClass()
        {
            string filePath = SerializeSystemFilePath();
            try
            {
                var serializer = new XmlSerializer(typeof(SystemSetting));

                var writer = new StreamWriter(filePath, false, new UTF8Encoding(false));
                serializer.Serialize(writer, this.systemSetting);
                writer.Close();
                writer.Dispose();
            }
            catch (Exception err)
            {
                throw (err);
            }
        }

        /// <summary>
        /// システム情報をデシリアライズ
        /// </summary>
        private void DeserializeClass()
        {
            string filePath = SerializeSystemFilePath();
            try
            {
                var serializer = new XmlSerializer(typeof(SystemSetting));

                var reader = new StreamReader(filePath, new UTF8Encoding(false));
                this.systemSetting = (SystemSetting)serializer.Deserialize(reader);
                reader.Close();
                reader.Dispose();
            }
            catch
            {
                //失敗したら諦める
                //throw (err);
            }
        }


        /// <summary>
        /// フレームレートとフレーム数から、再生時間を求める
        /// </summary>
        /// <param name="fps"></param>
        /// <param name="totalFrames"></param>
        /// <returns></returns>
        public string GetDurationString(long totalFrames)
        {
            double fps = 0;
            try
            {
                string[] fpsRateSplit = this.videoFile.fps.Split('/');
                fps = Convert.ToDouble(Convert.ToDouble(fpsRateSplit[0]) / Convert.ToDouble(fpsRateSplit[1]));

                double seconds = totalFrames / fps;
                var ts = TimeSpan.FromSeconds(seconds);

                return ts.ToString(@"hh\:mm\:ss\.fff");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "00:00:00";
        }



        /// <summary>
        /// ビデオファイルの設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetVideoFile()
        {
            //読込パスを初期化
            this.lordPath = string.Empty;
            try
            {
                // 読込パスを取得
                foreach (string args in this.ARGS)
                {
                    if (File.Exists(args))
                    {
                        this.lordPath = args;
                        break;
                    }
                }

                //
                if (this.lordPath == string.Empty)
                {
                    return;
                }
                else
                {


                    // 読込ビデオの更新
                    this.videoFile = new VideoFile();
                    this.videoFile.fullName = this.lordPath;
                    this.videoFile.name = Path.GetFileName(this.lordPath);


                    var info = FFmpegIO.GetVideoInfo(this.lordPath);
                    var root = info.RootElement;


                    // 最初の video stream を取得
                    this.ShowProgressBar(1, 3);
                    var videoStream = root
                        .GetProperty("streams")
                        .EnumerateArray()
                        .First(s => s.GetProperty("codec_type").GetString() == "video");

                    this.videoFile.codec = videoStream.GetProperty("codec_name").GetString();
                    this.videoFile.intWidth = videoStream.GetProperty("width").GetInt32();
                    this.videoFile.intHeight = videoStream.GetProperty("height").GetInt32();
                    this.videoFile.fps = videoStream.GetProperty("r_frame_rate").GetString();

                    // 数値のFPSを求める
                    string[] fpsRateSplit = this.videoFile.fps.Split('/');
                    try
                    {
                        this.videoFile.doubleFPS = Math.Round(Convert.ToDouble(fpsRateSplit[0]) / Convert.ToDouble(fpsRateSplit[1]), 2);    //小数点2桁に
                    }
                    catch
                    {
                        this.videoFile.doubleFPS = Math.Round(Convert.ToDouble(fpsRateSplit[1]), 2);    //小数点2桁に
                    }

                    // format 情報
                    this.ShowProgressBar(2, 3);
                    this.videoFile.format = root.GetProperty("format");

                    // ビデオ編集パネルの表示
                    this.ShowProgressBar(3, 3);
                    this.Show_pnlEditVideo();

                    // 既に出力済みかチェック
                    if (Directory.Exists(this.GetOutputPath()))
                    {
                        //既に出力済み
                        MessageBox.Show("It has already been output.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //出力済み回数を求める
                        this.GetOutputPath_CutOutCount();

                        // 次の作業グループボックスを表示する
                        this.SetGroupBoxNext();
                    }
                    else
                    {
                        // 次の作業グループボックスを非表示する
                        this.groupBoxNext.Visible = false;

                    }

                }



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
        /// ピクチャーボックスに画像を表示
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="videoPath"></param>
        /// <param name="fps"></param>
        /// <param name="frameNumber"></param>
        public void ShowFrame(StartEnd se)
        {
            string targetTime = string.Empty;
            PictureBox pb = new PictureBox();
            string trans = string.Empty; 
            try
            {
                if (se == StartEnd.Start)
                {
                    targetTime = this.lblTrimStartTime.Text;
                    pb = this.pictureBoxStart;
                }
                else
                {
                    targetTime = this.lblTrimEndTime.Text;
                    pb = this.pictureBoxEnd;
                }

                // 回転設定
                if(this.chkIsTranspose.Checked )
                {
                    if(this.rdoTranspose1.Checked )
                    {
                        trans = "1";
                    }
                    else
                    {
                        trans = "2";
                    }
                }

                //指定時間のフレーム画像を取得する
                string imgPath = FFmpegIO.ExtractFrameImage(se.ToString(), this.videoFile.fullName, targetTime, trans);

                if (File.Exists(imgPath))
                {
                    // 画像ファイルをロックしないように MemoryStream 経由で読み込む
                    using (var ms = new MemoryStream(File.ReadAllBytes(imgPath)))
                    {
                        pb.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        /// <summary>
        /// 取得フレーム件数をセット
        /// </summary>
        public void SetlblTotalFrameImageCout()
        {
            try
            {
                int startFrame = Convert.ToInt32(this.txtTrimStart.Text);
                int endFrame = Convert.ToInt32(this.txtTrimEnd.Text);
                int totalFrame = endFrame - startFrame;

                int imageCount = totalFrame / Convert.ToInt32(this.cmbFrameInterval.Text);

                this.lblTotalFrameImageCout.Text = "Tortal Frame Image: " + imageCount.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// フレームイメージの切り出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTEST_FFMPEG_Click(object sender, EventArgs e)
        {
            string trans = string.Empty;
            try
            {
                string outputPath = this.GetOutputPath();

                // 回転設定
                if (this.chkIsTranspose.Checked)
                {
                    if (this.rdoTranspose1.Checked)
                    {
                        trans = "1";
                    }
                    else
                    {
                        trans = "2";
                    }
                }

                // フォルダ確認
                if (Directory.Exists(outputPath))
                {
                    //追加出力確認
                    if (MessageBox.Show("It has already been output." + Environment.NewLine + "Would you like to output additional data ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                    {
                        return;
                    }
                }
                else
                {
                    //ディレクトリの作成
                    Directory.CreateDirectory(outputPath);
                }


                //エクスプローラーを開く
                Process.Start("explorer.exe", outputPath);


                //フレーム出力
                if (this.rdoPng.Checked)
                {
                    //PNG出力
                    FFmpegIO.ExtractFrames(this.videoFile.fullName,
                                            Convert.ToInt32(this.txtTrimStart.Text),
                                            Convert.ToInt32(this.txtTrimEnd.Text),
                                            Convert.ToInt32(this.cmbFrameInterval.Text),
                                            this.videoFile.doubleFPS,
                                            Path.Combine(outputPath, "frame_" + this.videoFile.intoutPutCount.ToString() + "_%06d.png"), trans);
                }
                else
                {
                    //JPG出力
                    FFmpegIO.ExtractFrames(this.videoFile.fullName,
                                            Convert.ToInt32(this.txtTrimStart.Text),
                                            Convert.ToInt32(this.txtTrimEnd.Text),
                                            Convert.ToInt32(this.cmbFrameInterval.Text),
                                            this.videoFile.doubleFPS,
                                            Path.Combine(outputPath, "frame_" + this.videoFile.intoutPutCount.ToString() + "_%06d.jpg"), trans);

                }

                //出力回数を加算
                this.videoFile.intoutPutCount++;


                // 次の作業グループボックスを表示する
                this.SetGroupBoxNext();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }


        /// <summary>
        /// 出力済みフォルダのカットアウトカウントを求める
        /// </summary>
        /// <returns></returns>
        private int GetOutputPath_CutOutCount()
        {
            int cutOutCount = 0;
            try
            {
                var dir = new DirectoryInfo(this.GetOutputPath());
                var newest = dir.GetFiles()
                                .OrderByDescending(f => f.LastWriteTime)
                                .FirstOrDefault();

                string[] fileNameSplit = newest.Name.Split('_');
                cutOutCount = Convert.ToInt32(fileNameSplit[1]);

                this.videoFile.intoutPutCount = cutOutCount + 1;  

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cutOutCount;
        }

        #endregion メソッド

        #region 動画編集パネル

        /// <summary>
        /// 動画編集パネルの表示
        /// </summary>
        private void Show_pnlEditVideo()
        {
            try
            {
                // オブジェクトの非表示
                this.lbl_PleaseDropDownVideo.Visible = false;
                this.lbl_PleaseDropDownVideo2.Visible = false;

                // オブジェクトの表示
                this.pnlEditVideo.Top = 58;
                this.pnlEditVideo.Left = 12;
                this.pnlEditVideo.Visible = true;
                this.pnlEditVideo.Focus();

                // フレーム総数の取得
                this.videoFile.intTotalFrameCount = FFmpegIO.GetTotalFrames(this.videoFile.fullName);

                // 画面項目の表示
                this.lblShowInfo.Text = "[" + this.videoFile.fullName + "]";
                this.lblShowInfo2.Text = "FrameCount: " + this.videoFile.intTotalFrameCount.ToString();
                this.lblShowInfo3.Text = "FPS: " + this.videoFile.fps;

                // スタート初期値
                this.trackBar_TrimStart.Maximum = this.videoFile.intTotalFrameCount - 1;
                this.trackBar_TrimStart.Value = 1;
                this.txtTrimStart.Text = this.trackBar_TrimStart.Value.ToString();

                // エンド初期値
                this.trackBar_TrimEnd.Maximum = this.videoFile.intTotalFrameCount;
                this.trackBar_TrimEnd.Value = this.trackBar_TrimEnd.Maximum;
                this.txtTrimEnd.Text = this.trackBar_TrimEnd.Value.ToString();

                //初期画像の設定
                if (this.videoFile.intTotalFrameCount > 300)
                {
                    //開始フレームを動画開始 3秒後
                    this.trackBar_TrimStart.Value = Convert.ToInt32(this.videoFile.doubleFPS * 3);

                    //終了フレームを動画終了 3秒前
                    this.trackBar_TrimEnd.Value = this.trackBar_TrimEnd.Maximum - Convert.ToInt32(this.videoFile.doubleFPS * 3);
                }


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// パッケージ作業のグループボックスの設定
        /// </summary>
        private void SetGroupBoxNext()
        {
            string outputPath = this.GetOutputPath();

            try
            {
                // 出力対象ディレクトリの存在チェック
                if (!Directory.Exists(outputPath))
                {
                    this.groupBoxNext.Visible = false;
                }
                else
                {
                    this.groupBoxNext.Visible = true;

                    //出力済みファイル件数を求める
                    DirectoryInfo di = new DirectoryInfo(outputPath);
                    FileInfo[] arrayFI = di.GetFiles();

                    this.txtCutOutPath.Text = outputPath;
                    this.lblOutputFiles.Text = "Tortal CutOut Image Count: " + arrayFI.Length.ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion 動画編集パネル

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
                if (setValue != 0)
                {
                    percent = (double)setValue / maximum * 100;
                }

                this.lblShowInfo.Text = $"Please Wait ...Now {percent:F2} %";
                this.lblShowInfo2.Text = "[" + setValue.ToString() + "/" + maximum.ToString() + "]";

                this.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion プログレスバー

        #region FFMPEG


        #endregion FFMPEG
    }
}
