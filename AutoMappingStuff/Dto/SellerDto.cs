using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingStuff.Dto
{
    public class SellerDto : PersonDto
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
    }
}
