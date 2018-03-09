using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 数据采集
{
    public class ImageSave
    {
        private string _base_url = @"D:\\images\\net";

        public async Task save(string url, string fileName)
        {
            if (File.Exists(_base_url + fileName))
            {
                return new Task<Object>();
            }

            byte[] bytes = await NetHelper.getImageContent(url);

            using (FileStream fs = new FileStream(_base_url + fileName, FileMode.OpenOrCreate))
            {
                await fs.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}