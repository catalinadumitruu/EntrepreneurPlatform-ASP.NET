using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task_WebAndCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Task_WebAndCloud.Data
{
	public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options) {
			_httpContextAccessor = httpContextAccessor;
		}

        public DbSet<Post> Posts { get; set; }
	}
}