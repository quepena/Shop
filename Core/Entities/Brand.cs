using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{

    public class Brand : BaseEntity
    {
        public string Name { get; set; }
    }
}