using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IgDotNetAPI.Models
{
    [Table("followers")]
    public class Follower
    {
        public ILazyLoader LazyLoader { get; }
        public Follower() { }
        public Follower(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        public string UserId { get; set; }
        Person user;
        [ForeignKey("UserId")]
        public Person User { get => LazyLoader.Load(this, ref user); set => user = value; }
        public string UserFollowerId { get; set; }
        Person userFollower;
        [ForeignKey("UserFollowerId")]
        public Person UserFollower { get => LazyLoader.Load(this, ref userFollower); set => userFollower = value; }

    }
}
