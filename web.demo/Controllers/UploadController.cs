using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
namespace Web.Demo.Controllers
{
    public class UploadController : BaseController
    {

        private static int j = 0;
        private int i = 0;

        /// <summary>
        ///  allowedExtensions: ['gif', 'png', 'jpg', 'jpeg', 'pdf', 'rar', 'zip'],
        /// </summary>
        private static readonly string[] IMG_EXTENSION = { ".gif", ".png", ".jpg", ".jpeg" };
        // GET: Upload
        public ActionResult Index()
        {
            return View();

        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            const string virtualPath = "\\upload\\";
            
            try
            {
                if (file == null)
                {
                    return Fail("没有上传图片");
                }
                //if (string.IsNullOrWhiteSpace(file.FileName))
                //{
                //    return Fail("图片没有名称");
                //}
                string extension = Path.GetExtension(file.FileName);
                if (IMG_EXTENSION.Any(x => x.Equals(extension, StringComparison.CurrentCultureIgnoreCase)) == false)
                {
                    return Fail("图片格式不符合要求");
                }
                //真实路径
                string truePath = Server.MapPath(virtualPath);
                if (Directory.Exists(truePath) == false)
                {
                    Directory.CreateDirectory(truePath);
                }
                string newFileName = Guid.NewGuid().ToString() + extension;
                //真实地址
                string newFilePath = Path.Combine(truePath, newFileName);
                using (Stream imageStream = file.InputStream)
                {
                    getThumImage(imageStream, 85L, 1, newFilePath);
                }
                return Success("上传成功", new {imagePath=virtualPath+newFileName ,fileName=file.FileName});
            }
            catch (Exception ex)
            {
                return Fail(string.Format("上传失败:{0}",ex.Message));
            }
        }

        #region getThumImage
        /// <summary>  
        /// 生成缩略图  http://blog.csdn.net/qq_16542775/article/details/51792149
        /// </summary>  
        /// <param name="sourceFile">原始图片文件</param>  
        /// <param name="quality">质量压缩比</param>  
        /// <param name="multiple">收缩倍数</param>  
        /// <param name="outputFile">输出文件名</param>  
        /// <returns>成功返回true,失败则返回false</returns>  
        public static bool getThumImage(Stream imageStream, long quality, int multiple, String outputFile)
        {
            try
            {
                //TODO如果图片过大，则进行收缩倍数                                                                                                                                                                                                                                                                                          
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(imageStream);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width;
                float yWidth = sourceImage.Height;
                Bitmap newImage = new Bitmap((int)(xWidth / multiple), (int)(yWidth / multiple));
                Graphics g = Graphics.FromImage(newImage);
                g.DrawImage(sourceImage, 0, 0, xWidth / multiple, yWidth / multiple);
                g.Dispose();
                newImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion getThumImage

        /**/
        /// <summary>  
        /// 获取图片编码信息  
        /// </summary>  
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }



        #region 测试
        /// <summary>
        /// 此结果证明，.net mvc针对每次请求（action），都实例化一个controller，当然，这样属性其实应该没什么卵用
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOne() {
        
            i++;
            Thread.Sleep(1000);
            Debug.WriteLine(i);
 
            return ToJson(i);
        }


        public ActionResult GetTwo()
        {
            i++;
            Thread.Sleep(1000);
            Debug.WriteLine(i);
            return ToJson(i);
        }
        #endregion


    }
}