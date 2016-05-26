using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Api
{
    public class Update
    {
        public Guid Id { get; private set; }
        public string Text { get; private set; }
        public Image Photo { get; set; }

        public Update(string text)
        {
            Id = Guid.NewGuid();
        }

        public Update SetText(string text)
        {
            Text = text;
            return this;
        }

        public Update SetPhoto(Image photo)
        {
            Photo = photo;
            return this;
        }
    }
}
