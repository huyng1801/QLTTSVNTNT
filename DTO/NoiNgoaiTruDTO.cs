using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NoiNgoaiTruDTO
    {
        public string Ma { get; set; }
        public string MaSinhVien { get; set; }

        public DateTime TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public string Loai { get; set; }
    }
}
