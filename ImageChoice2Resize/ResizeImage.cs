using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageChoiceAndResize
{
    class ResizeImage
    {



        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="outputPath"></param>
        /// <param name="targetWidht"></param>
        public void Resize(string inputPath, string outputPath, int targetWidht, ImageFormat imageFormat)
        {
            try
            {
                using (var src = Image.FromFile(inputPath))
                {
                    // 縦幅を求める
                    int targetHeight = (int)Math.Round(src.Height * (targetWidht / (double)src.Width));
                    using (var dst = new Bitmap(targetWidht, targetHeight))
                    using (var g = Graphics.FromImage(dst))
                    {
                        // 高品質設定
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        //リサイズ描画
                        g.DrawImage(src, 0, 0, targetWidht, targetHeight);

                        // JPEG (90)で保存
                        if (imageFormat == ImageFormat.Jpeg)
                        {                            
                            var encoder = GetEncoder(ImageFormat.Jpeg);
                            var ep = new EncoderParameters(1);
                            ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                            dst.Save(outputPath, encoder, ep);
                        }
                        else if (imageFormat == ImageFormat.Png)
                        {
                            var encoder = GetEncoder(ImageFormat.Png);
                            var ep = new EncoderParameters(1);
                            ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                            dst.Save(outputPath, encoder, ep);
                        }

                        
                    }
                }
            }
            catch (Exception err)
            {
                throw (err);
            }
        }

        /// <summary>
        /// 画像フォーマットに対応するエンコーダ取得
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            foreach (var c in ImageCodecInfo.GetImageDecoders())
            {
                if (c.FormatID == format.Guid) return c;
            }
            return null;
        }
    }
}
