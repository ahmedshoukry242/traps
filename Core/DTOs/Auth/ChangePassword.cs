using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Auth
{
    public class ChangePassword
    {
        public string User_Id { get; set; } = string.Empty;
        public string OldPassWord { get; set; } = string.Empty;

        [MinLength(6)]
        public string NewPassWord { get; set; } = string.Empty;

        [MinLength(6)]
        public string ConfirmNewPassWord { get; set; } = string.Empty;
    }
}
