using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IgDotNetAPI.Models
{
    public class Like
    {
        public ILazyLoader LazyLoader { get; }
        public Like() { }
        public Like(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public string PostId { get; set; }
        public string UserId { get; set; }
        Person user;
        [ForeignKey("UserId")]
        public Person User { get => LazyLoader.Load(this, ref user); set => user = value; }

    }
}
