using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EPOCH.BACKEND
{
	[Table("tbl_accounts")]
    public class Account : BaseClass ,IAccount
    {
		[Column("username")]
		public string AccountName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("secret_question")]
        public int SecretQuestion { get; set; }

        [Column("secret_answer")]
        public string SecretAnswer { get; set; }
    }
}
