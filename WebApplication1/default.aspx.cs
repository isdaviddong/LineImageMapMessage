using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "!!!!! 改成自己的ChannelAccessToken !!!!!";
        const string AdminUserId = "!!!改成你的AdminUserId!!!";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            isRock.LineBot.ImagemapMessage imagemapMessage = new ImagemapMessage();
            imagemapMessage.altText = "imagemapMessage test";
            imagemapMessage.baseSize = new System.Drawing.Size(1040, 1040);
            imagemapMessage.baseUrl = new Uri($"https://arock.blob.core.windows.net/test3/");
            imagemapMessage.actions = new List<ImagemapActionBase>();
            imagemapMessage.actions.Add(new isRock.LineBot.ImagemapMessageAction()
            {
                area = new ImagemapArea() { x = 0, y = 0, height = 500, width = 500 },
                text = "點選了(0,0) - (500,500)"
            });
            imagemapMessage.actions.Add(new isRock.LineBot.ImagemapMessageAction()
            {
                area = new ImagemapArea() { x = 500, y = 500, height = 1040, width = 1040 },
                text = "點選了(500,500) - (1040,1040)"
            });
            bot.PushMessage(AdminUserId, imagemapMessage.baseUrl.ToString());
            bot.PushMessage(AdminUserId, imagemapMessage);
        }
    }
}