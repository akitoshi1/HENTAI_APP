using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Reflection;

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
            /// 出力ディレクトリ(V2FI)
            /// </summary>
            public string OutputDirectory { get; set; }

            /// <summary>
            /// 出力ディレクトリ(V2V)
            /// </summary>
            public string OutputDirectoryV2V { get; set; }

            /// <summary>
            /// フレーム出力を使わない(ラジオボタンが非表示)
            /// </summary>
            public bool DontUseV2FI = false;

            /// <summary>
            /// 動画出力を使わない(ラジオボタンが非表示)
            /// </summary>
            public bool DontUseV2V = false;
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

            /// <summary>
            /// 動画出力した回数
            /// </summary>
            public int intoutV2VCount = 0;

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
        public string SYSTEM_INFO = "[https://civitai.com/user/suteakasuteakasuteka434]" + Assembly.GetExecutingAssembly().GetName().Version;

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
            R1, L2
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
        /// 左クリック中
        /// </summary>
        public bool blnLeftClick = false;

        /// <summary>
        /// 画像ファイルのパスを返す
        /// </summary>
        /// <param name="se"></param>
        /// <returns></returns>
        private string GetImageFilePath(StartEnd se)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), se.ToString() + ".png");
        }


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
        /// 出力フォルダの取得
        /// </summary>
        /// <returns></returns>
        public string GetOutputV2VPath()
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
                    if (this.systemSetting.OutputDirectoryV2V != null)
                    {
                        // 出力フォルダ+動画ファイル名（拡張子なし）
                        outputPath = Path.Combine(this.systemSetting.OutputDirectoryV2V, Path.GetFileNameWithoutExtension(this.videoFile.fullName));
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

                // ffMpegの存在チェック
                if (FFmpegIO.GetFFmpegVersion() == string.Empty)
                {
                    //FFmpegが未インストール
                    this.lbl_PleaseDropDownVideo.Text = "FFmpeg is not installed.  Please install FFmpeg.";
                    this.lbl_PleaseDropDownVideo2.Text = "🫷 😵‍💫 🫸";
                    this.Text = "FFmpeg is not installed.  Please install FFmpeg.";

                    return;
                }

                //パネルのアンカー初期化
                this.pnlEditVideo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

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

                toolTip.SetToolTip(this.btnSystemOutput, "Select Flame Image Output Folder");  //出力先選択
                toolTip.SetToolTip(this.btnSystemSettingClose, "System Setting End");          //システム設定終了
                toolTip.SetToolTip(this.btnTEST_FFMPEG, "Video 2 FrameImage Files");           //フレーム画像の出力
                toolTip.SetToolTip(this.btnSend_Packer, "Go 2 Next Work!!");                   //次の処理へ

                toolTip.SetToolTip(this.btnV2V_FFMPEG, "Video 2 Clip Video File");              //フレーム指定動画の出力
                toolTip.SetToolTip(this.btnV2TXT, "Create Brank Caption Text File");           //空のキャプションファイルを作成する

                //利用しない設定
                this.SetDontUse();
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
                // 左クリック中ならなにもしない
                if (this.blnLeftClick == true)
                {
                    //一応ここで通知も解除しておく
                    this.blnLeftClick = false;
                    return;
                }

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
        /// スタート画像のドラッグ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxStart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 左クリック中をアプリに通知
                this.blnLeftClick = true;

                System.IO.FileInfo fi = new FileInfo(this.GetImageFilePath(StartEnd.Start));
                if (fi.Exists)
                {
                    string[] files = { (string)fi.FullName };
                    DataObject dataObj = new DataObject(DataFormats.FileDrop, files);
                    DragDropEffects dde = this.pictureBoxStart.DoDragDrop(dataObj, DragDropEffects.Copy);
                }

                // 左クリック中の通知を解除
                this.blnLeftClick = false;
            }
        }

        /// <summary>
        /// エンド画像のドラッグ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxEnd_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 左クリック中をアプリに通知
                this.blnLeftClick = true;

                System.IO.FileInfo fi = new FileInfo(this.GetImageFilePath(StartEnd.End));
                if (fi.Exists)
                {
                    string[] files = { (string)fi.FullName };
                    DataObject dataObj = new DataObject(DataFormats.FileDrop, files);
                    DragDropEffects dde = this.pictureBoxEnd.DoDragDrop(dataObj, DragDropEffects.Copy);
                }

                // 左クリック中の通知を解除
                this.blnLeftClick = false;
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

                if (valutTB > this.trackBar_TrimStart.Minimum)
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
                string outPutPath = this.GetOutputPath();
                var psi = new ProcessStartInfo
                {
                    FileName = this.GetNextAppPath(),
                    Arguments = $"\"{outPutPath}\""
                };

                //次のアプリを開く
                Process.Start(psi);

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
            //this.Width = 700;
            //this.Height = 300;

            //システム設定値を表示
            this.txtSystemOutput.Text = this.systemSetting.OutputDirectory;
            this.txtSystemOutputV2V.Text = this.systemSetting.OutputDirectoryV2V;
            this.chkDontUseV2FI.Checked = this.systemSetting.DontUseV2FI;
            this.chkDontUseV2V.Checked = this.systemSetting.DontUseV2V;


            this.pnlSystemSeting.Top = 58;
            this.pnlSystemSeting.Left = 12;
            this.pnlSystemSeting.Visible = true;
            this.pnlSystemSeting.Focus();

            this.pnlsplitContainer1.Visible = false;
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
                this.pnlsplitContainer1.Visible = true;

                //システム設定の更新
                this.systemSetting.OutputDirectory = this.txtSystemOutput.Text;
                this.systemSetting.OutputDirectoryV2V = this.txtSystemOutputV2V.Text;
                this.systemSetting.DontUseV2FI = this.chkDontUseV2FI.Checked;
                this.systemSetting.DontUseV2V = this.chkDontUseV2V.Checked;                  

                //システム情報をシリアライズ
                this.SerializeClass();

                this.Width = 1030;
                this.Height = 750;

                //利用しない設定
                this.SetDontUse();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 利用しない設定
        /// </summary>
        private void SetDontUse()
        {
            bool isVisibleV2FI = false;
            bool isVisibleV2V = false;
            try
            {
                // V2FIの利用設定
                if(this.systemSetting.DontUseV2FI )
                {
                    isVisibleV2FI = false;
                }
                else
                {
                    isVisibleV2FI = true;
                }
                
                // V2Vの利用設定
                if(this.systemSetting.DontUseV2V )
                {
                    isVisibleV2V = false;
                }
                else
                {
                    isVisibleV2V = true;
                }

                // V2FI関係
                this.rdoJpg.Visible = isVisibleV2FI;
                this.rdoPng.Visible = isVisibleV2FI;
                this.btnTEST_FFMPEG.Visible = isVisibleV2FI;

                // V2V関係
                this.rdoMp4.Visible = isVisibleV2V;
                this.btnV2V_FFMPEG.Visible = isVisibleV2V;
                this.lblV2V.Visible = isVisibleV2V;

                if(isVisibleV2FI == false )
                {
                    this.rdoMp4.Checked = true; 
                }
                if(isVisibleV2V == false )
                {
                    this.rdoJpg.Checked = true;
                }
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
                // プログレスバーを表示
                this.progressBar.Visible = true;
                Application.DoEvents();
                this.Refresh();




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
                    //this.ShowProgressBar(1, 3);
                    Application.DoEvents();
                    this.Refresh();

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
                    //this.ShowProgressBar(2, 3);
                    this.videoFile.format = root.GetProperty("format");
                    Application.DoEvents();
                    this.Refresh();

                    // ビデオ編集パネルの表示
                    //this.ShowProgressBar(3, 3);
                    this.Show_pnlEditVideo();
                    Application.DoEvents();
                    this.Refresh();

                    // 既に出力済みかチェック
                    if (Directory.Exists(this.GetOutputPath()))
                    {
                        //既に出力済み
                        MessageBox.Show("It has already been output.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //出力済み回数を求める
                        this.GetOutputPath_CutOutCount();

                        // 次の作業グループボックスを表示する
                        this.SetGroupBoxNext();
                        this.SetGroupBoxMP4();
                    }
                    else
                    {
                        // 次の作業グループボックスを非表示する
                        this.groupBoxNext.Visible = false;
                        this.groupBoxMP4.Visible = false; 

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


                if (rdoMp4.Checked)
                {
                    //ビデオ出力の場合
                    TimeSpan tsStart = TimeSpan.Parse (  this.lblTrimStartTime.Text);
                    TimeSpan tsEnd = TimeSpan.Parse(this.lblTrimEndTime.Text);
                    TimeSpan ts = tsEnd - tsStart;

                    this.lblTotalFrameImageCout.Text = "Clip Video Time: " + ts.ToString(@"hh\:mm\:ss") ;
                }
                else
                {
                    //フレームイメージ出力の場合
                    this.lblTotalFrameImageCout.Text = "Tortal Frame Image: " + imageCount.ToString();
                }
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
                    .Where(x => x.Extension != ".mp4")
                    .OrderByDescending(f => f.LastWriteTime)                                
                                .FirstOrDefault();

                string[] fileNameSplit = newest.Name.Split('_');

                try
                {
                    cutOutCount = Convert.ToInt32(fileNameSplit[1]);
                    this.videoFile.intoutPutCount = cutOutCount + 1;
                }
                catch
                {
                    //失敗するのは別物なので無視する
                }
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
                this.pnlsplitContainer1.Visible = true;

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
                else
                {
                    //開始フレームを動画開始 
                    this.trackBar_TrimStart.Value = 2;

                    //終了フレームを動画終了 
                    this.trackBar_TrimEnd.Value = this.trackBar_TrimEnd.Maximum - 1;

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
            string[] extensions = { "*.png", "*.jpg" };
            try
            {
                // 出力対象ディレクトリの存在チェック
                if (!Directory.Exists(outputPath))
                {
                    this.groupBoxNext.Visible = false;
                }
                else
                {                    
                    //出力済み画像ファイル件数を求める                    
                    int count = extensions
                        .SelectMany(ext => Directory.GetFiles(outputPath, ext))
                        .Count();

                    if (count > 0)
                    {
                        this.groupBoxNext.Visible = true;

                        this.txtCutOutPath.Text = outputPath;
                        this.lblOutputFiles.Text = "Tortal CutOut Image Count: " + count.ToString();
                    }
                    else
                    {
                        this.groupBoxNext.Visible = false ;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 出力済み動画件数グループボックスの設定
        /// </summary>
        private void SetGroupBoxMP4()
        {
            string outputPath = this.GetOutputV2VPath();
            try
            {
                // 出力対象ディレクトリの存在チェック
                if (!Directory.Exists(outputPath))
                {
                    this.groupBoxMP4.Visible = false;
                }
                else
                {

                    //出力済み動画ファイル件数を求める
                    int count = this.GetOutputMp4Count();

                    if (count > 0)
                    {
                        this.groupBoxMP4.Visible = true;
                        this.lblOutputMp4Files.Text = "Tortal Clip Video Count: " + count.ToString();
                    }
                    else
                    {
                        this.groupBoxMP4.Visible = false;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 出力済み動画件数を求める
        /// </summary>
        /// <returns></returns>
        private int GetOutputMp4Count()
        {
            string outputPath = this.GetOutputV2VPath();
            string extension = "*.mp4";
            try
            {
                //出力済み動画ファイル件数を求める
                int count = Directory.GetFiles(outputPath, extension).Length;

                this.videoFile.intoutV2VCount = count + 1;

                return count;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
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

                Application.DoEvents();
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


        /// <summary>
        /// 動画ファイルの切り出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnV2V_FFMPEG_Click(object sender, EventArgs e)
        {
            string trans = string.Empty;
            try
            {
                string outputPath = this.GetOutputV2VPath();

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
                }
                else
                {
                    //ディレクトリの作成
                    Directory.CreateDirectory(outputPath);
                }


                //エクスプローラーを開く
                Process.Start("explorer.exe", outputPath);


                //出力ファイル名の重複チェック
                string outputFilePath = Path.Combine(outputPath, "Clip_" + this.videoFile.intoutV2VCount.ToString() + ".mp4");
                if (File.Exists(outputFilePath))
                {
                    for (int i = 1; i < 10000; i++)
                    {
                        this.videoFile.intoutV2VCount = this.videoFile.intoutV2VCount + i;
                        outputFilePath = Path.Combine(outputPath, "Clip_" + this.videoFile.intoutV2VCount.ToString() + ".mp4");
                        if (!File.Exists(outputFilePath))
                        {
                            break;
                        }
                    }
                }

                //フレーム出力
                //MP4出力
                FFmpegIO.ExtractV2V(this.videoFile.fullName,
                                        Convert.ToInt32(this.txtTrimStart.Text),
                                        Convert.ToInt32(this.txtTrimEnd.Text),                                        
                                        this.videoFile.doubleFPS,
                                        Path.Combine(outputPath, "Clip_" + this.videoFile.intoutV2VCount.ToString() + ".mp4"), trans);

                //出力回数を加算
                this.videoFile.intoutV2VCount++;


                // 次の作業グループボックスを表示する
                this.SetGroupBoxMP4();

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoJpg_Validated(object sender, EventArgs e)
        {
            this.rdoJpgPngMp4_CheckedChanged( sender,  e);
        }
        private void rdoJpg_CheckedChanged(object sender, EventArgs e)
        {
            this.rdoJpgPngMp4_CheckedChanged(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoPng_CheckedChanged(object sender, EventArgs e)
        {
            this.rdoJpgPngMp4_CheckedChanged(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoMp4_CheckedChanged(object sender, EventArgs e)
        {
            this.rdoJpgPngMp4_CheckedChanged(sender, e);
        }

        /// <summary>
        /// ラジオボタンに該当するボタンの有効化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoJpgPngMp4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            switch (rb.Text)
            {
                case "JPG":
                case "PNG":
                    this.btnTEST_FFMPEG.Enabled = true;
                    this.btnV2V_FFMPEG.Enabled = false; 
                    break;

                case "MP4":
                    this.btnTEST_FFMPEG.Enabled = false;
                    this.btnV2V_FFMPEG.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// mp4ファイルと同名のテキストファイルを作成する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnV2TXT_Click(object sender, EventArgs e)
        {
            string outputPath = this.GetOutputV2VPath();
            string extension = "*.mp4";

            int outCount = 0;   //出力件数
            try
            {
                //出力済み動画ファイル件数を求める
                string [] arrayMp4  = Directory.GetFiles(outputPath, extension);
                
                foreach (string mp4 in arrayMp4 )
                {
                    string txtName = Path.GetFileNameWithoutExtension(mp4) + ".txt";
                    string txtPath = Path.Combine(outputPath, txtName);

                    //テキストファイルが存在しないなら空ファイルを作成する
                    if(!File.Exists(txtPath) )
                    {
                        File.WriteAllText(txtPath, string.Empty);

                        outCount++;
                    }
                }

                //エクスプローラーを開く
                Process.Start("explorer.exe", outputPath);

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
        private void chkDontUseV2FI_CheckedChanged(object sender, EventArgs e)
        {
            bool blnVisible = false;
            if(this.chkDontUseV2FI.Checked  )
            {
                blnVisible = false;
            }
            else
            {
                blnVisible = true;
            }

            this.lblSystemOutput.Visible = blnVisible;
            this.txtSystemOutput.Visible = blnVisible;
            this.btnSystemOutput.Visible = blnVisible;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkDontUseV2V_CheckedChanged(object sender, EventArgs e)
        {
            bool blnVisible = false;
            if (this.chkDontUseV2V.Checked)
            {
                blnVisible = false;
            }
            else
            {
                blnVisible = true;
            }

            this.lblSystemOutputV2V.Visible = blnVisible;
            this.txtSystemOutputV2V.Visible = blnVisible;
            this.btnSystemOutputV2V.Visible = blnVisible;
        }

        /// <summary>
        /// フォルダを開くボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSystemOutputV2V_Click(object sender, EventArgs e)
        {

            var dialog = new FolderBrowserDialog();

            dialog.Description = "フォルダを選択してください";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtSystemOutputV2V.Text = dialog.SelectedPath;
                this.systemSetting.OutputDirectoryV2V = this.txtSystemOutputV2V.Text;
            }
        }

    }

}
