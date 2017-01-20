using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace web.sample
{
    /// <summary>
    /// 图片截取
    /// </summary>
    public class ImageCopper
    {
        /// <summary>
        /// jcrop x
        /// </summary>
        public int X { get; set; }

       /// <summary>
        /// jcrop y
       /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// jcrop Width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// jcrop Height
        /// </summary>
        public int Height { get; set; }


        public string ImagePath { get; set; }


        public string SavePath { get; set; }

         public void Cut()
        {

            using (Image img = Image.FromFile(ImagePath))
            {
                using (Bitmap _bitmap = GenerateThumbnail(600, 430, img))//生成缩略图，因为原图可能比较大，所以要生成一张和截取图片一样大的图片(原图可能是1980*1200的，但是截取的显示框只有600*430，所以先截取)
                {
                    ImageCropper(_bitmap, System.Drawing.Imaging.ImageFormat.Png);
                    //return Json(new { isSuccess = true, fileName = newFileName + extension });
                }
            }
        }
        /// <summary>  
        /// 生成指定大小的图片(压缩)
        /// </summary>  
        /// <param name="maxWidth">生成图片的最大宽度</param>  
        /// <param name="maxHeight">生成图片的最大高度</param>  
        /// <param name="imgFileStream">图片文件流对象</param>  
        private Bitmap GenerateThumbnail(int maxWidth, int maxHeight, Image img)
        {
            try
            {
                //用指定的大小和格式初始化Bitmap类的新实例
                Bitmap bitmap = new Bitmap(maxWidth, maxHeight, PixelFormat.Format32bppArgb);
                using (var graphic = GetGraphic(img, bitmap))
                {
                    graphic.DrawImage(img, new Rectangle(0, 0, maxWidth, maxHeight));
                    return bitmap;
                }

            }
            catch (Exception e)
            {
                throw e;
            }


        }
        // <summary>  
        /// 截取图片中的一部分  
        /// </summary>  
        /// <param name="img">待截取的图片</param>  
        /// <param name="cropperWidth">截取图片的宽</param>  
        /// <param name="cropperHeight">截取图片的高</param>  
        /// <param name="offsetX">水平偏移量</param>  
        /// <param name="offsetY">垂直偏移量</param>  
        /// <param name="savePath">截取后的图片保存位置</param>  
        /// <param name="imgFormat">截取后的图片保存格式</param>  
        private void ImageCropper(Image img,System.Drawing.Imaging.ImageFormat imgFormat)
        {
          
            var aa = imgFormat.ToString();
            using (var bmp = new System.Drawing.Bitmap(this.Width, this.Height))
            {
                //从Bitmap创建一个System.Drawing.Graphics对象，用来绘制高质量的缩小图。  
                using (var gr = GetGraphic(img, bmp))
                {
                    //把原始图像绘制成上面所设置宽高的截取图  
                    var rectDestination = new System.Drawing.Rectangle(X, Y, this.Width, this.Height);//生成截取区域
                    gr.DrawImage(img, 0, 0, rectDestination,  System.Drawing.GraphicsUnit.Pixel);
                    using (var encoderParameters = new EncoderParameters(1))
                    {
                        encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);//100表示图片压缩质量 压缩质量(数字越小压缩率越高) 1-100
                        bmp.Save(SavePath, ImageCodecInfo.GetImageEncoders().Where(x => x.FilenameExtension.Contains(imgFormat.ToString().ToUpperInvariant())).FirstOrDefault(), encoderParameters);
                    }
                }
            }
        }


        /// <summary>
        /// 获取图片压缩质量配置
        /// </summary>
        /// <param name="originImage"></param>
        /// <param name="newImage"></param>
        /// <returns></returns>
         private Graphics GetGraphic(Image originImage, Bitmap newImage)
        {
            newImage.SetResolution(originImage.HorizontalResolution, originImage.VerticalResolution);
            var graphic = Graphics.FromImage(newImage);
            graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            return graphic;
        }
    }

}