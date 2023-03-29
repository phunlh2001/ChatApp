using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ChatApp.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Username must be not empty"), MaxLength(20)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password must be not empty"), MinLength(6, ErrorMessage = "Password must be greater than 6 characters")]
        public string Password { get; set; }
        public string Avatar { get; set; } = RandomCustom.GetImage();
        public string CreateAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
    }

    public class RandomCustom
    {
        public static string GetImage()
        {
            Random rand = new Random();
            string[] imageFiles = Directory.GetFiles(@"wwwroot\images", "*.png");

            string randomImage = imageFiles[rand.Next(imageFiles.Length)];
            string imageName = Path.GetFileName(randomImage);
            if (imageName.Contains(@"wwwroot\images\"))
            {
                imageName = imageName.Substring(@"wwwroot\images\".Length);
            }
            return imageName;
        }
    }
}
