using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;



namespace Civitai_Love
{



    /// <summary>
    /// 
    /// </summary>
    public static class FFmpegIO
    {
        /// <summary>
        /// 動画情報の取得
        /// </summary>
        /// <param name="videoPath"></param>
        /// <returns></returns>
        public static JsonDocument GetVideoInfo(string videoPath)
        {
            string output = string.Empty;
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "ffprobe",
                    Arguments = $"-v quiet -print_format json -show_format -show_streams \"{videoPath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(psi))
                {
                    output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return JsonDocument.Parse(output);

        }

        /// <summary>
        /// 動画の総フレーム数を取得
        /// </summary>

        public static int GetTotalFrames(string videoPath)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "ffprobe",
                    Arguments = $"-v error -select_streams v:0 -count_packets -show_entries stream=nb_read_packets -of csv=p=0  \"{videoPath}\"",

                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd().Trim();
                    process.WaitForExit();

                    if (int.TryParse(output, out int frames))
                    {
                        return frames;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return 0;
        }


        /// <summary>
        /// 動画のフレームを指定して画像を取得する
        /// </summary>
        /// <param name="videoPath"></param>
        /// <param name="fps"></param>
        /// <param name="frameNumber"></param>
        /// <returns></returns>
        public static string ExtractFrameImage(string fileName, string videoPath, string time, string transpose)
        {
            
            //string tempImage = Path.Combine(AppContext.BaseDirectory, fileName + ".png");
            string tempImage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), fileName + ".png");
            try
            {
                // 出力ファイルが存在するなら削除
                if (File.Exists(tempImage))
                {
                    File.Delete(tempImage);
                }


                // FFMPEG コマンド編集
                var arguments = $"-nostdin -ss {time} -i \"{videoPath}\" -frames:v 1 \"{tempImage}\"";

                // 回転設定があるなら修正
                if (transpose != string.Empty )
                {
                    arguments = $"-nostdin -ss {time} -i \"{videoPath}\" -vf \"transpose={transpose}\" -frames:v 1 \"{tempImage}\"";
                }

                // FFMPEG プロセス起動
                using (var process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg",
                        Arguments = arguments,
                        CreateNoWindow = true,
                        UseShellExecute = false,
                    };
                    process.Start();
                    process.WaitForExit();
                }

                return tempImage;



            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return string.Empty;

        }

        /// <summary>
        /// 動画を指定間隔でフレーム出力
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="startFrame"></param>
        /// <param name="endFrame"></param>
        /// <param name="interval"></param>
        /// <param name="fps"></param>
        /// <param name="outputPattern"></param>
        public static void ExtractFrames(
                                            string inputPath,
                                            int startFrame,
                                            int endFrame,
                                            int interval,
                                            double fps,
                                            string outputPattern,
                                            string transpose)
        {
            try
            {
                double startSec = startFrame / fps;
                double endSec = endFrame / fps;

                // interval フレームごと → fps / interval
                double extractFps = fps / interval;

                var arguments = $"-ss {startSec} -to {endSec} -i \"{inputPath}\" " + $"-vf \"fps={extractFps}\" ";

                // 回転設定があるなら修正
                if (transpose != string.Empty)
                {
                    arguments = $"-ss {startSec} -to {endSec} -i \"{inputPath}\" " + $"-vf \"fps={extractFps},transpose={transpose}\" ";                    
                }

                // ファイル形式確認
                if (Path.GetExtension(outputPattern) == ".jpg")
                {
                    //.jpgなら、ファイル品質のオプション追加
                    arguments += $" -q:v 2 \"{outputPattern}\"";
                }
                else
                {
                    //.pngなら、
                    arguments += $" \"{outputPattern}\"";
                }


                using (var process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg",
                        Arguments = arguments,
                        CreateNoWindow = true,
                        UseShellExecute = false,
                    };
                    process.Start();
                    process.WaitForExit();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



    }



}