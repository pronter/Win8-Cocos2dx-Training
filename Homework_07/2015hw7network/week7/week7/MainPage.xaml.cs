using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace week7
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string getUrl = "http://222.200.185.43:8000/rank/getScore/?id={0}&num={1}";
        private string postUrl = "http://222.200.185.43:8000/rank/newScore/";
        private List<Record> rec;
        public MainPage()
        {
            this.InitializeComponent();
            Get(Convert.ToInt32(gameid.Text), 10);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Get(Convert.ToInt32(gameid.Text), 10);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Post(gameid.Text, name.Text, mark.Text, words.Text);
        }

        private async void Get(int gameid, int number)
        {
            try
            {
                status.Text = "Waiting for response ...";
                HttpClient httpClient = new HttpClient();
                var headers = httpClient.DefaultRequestHeaders;
                // 添加HTTP头
                headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 6.2; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
                // 根据用户输入的gameid，number来进行字符串格式化，变量getUrl在上面可以找到
                // 自己采用自己喜欢的方法，反正得到http://222.200.185.43:8000/rank/getScore/?id=gameid&num=number这url就行
                string url = string.Format(getUrl, gameid, number);
                // 使用get方法请求url
                HttpResponseMessage response = await httpClient.GetAsync(url);
                // 响应失败将抛出异常
                response.EnsureSuccessStatusCode();
                status.Text = response.StatusCode + " " + response.ReasonPhrase + Environment.NewLine;
                // 获取返回内容
                string rescontent = await response.Content.ReadAsStringAsync();
                XmlDocument xmlDoc = new XmlDocument();
                // 对返回回来的xml进行解析
                xmlDoc.LoadXml(rescontent);
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList users = root.SelectNodes("/records/item/user");
                XmlNodeList scores = root.SelectNodes("/records/item/score");
                XmlNodeList wordss = root.SelectNodes("/records/item/words");
                rec = new List<Record>();
                for (int i = 0; i < users.Length; i++)
                {
                    rec.Add(new Record() { User = users[i].InnerText, Score = scores[i].InnerText, Words = wordss[i].InnerText });
                }
                recordList.ItemsSource = rec;
            }
            catch (HttpRequestException hre)
            {
                status.Text = hre.ToString();
            }
            catch (Exception ex)
            {
                status.Text = ex.ToString();
            }
        }

        private async void Post(string gameid, string name, string mark, string words)
        {
            try
            {
                status.Text = "Waiting for response ...";
                HttpClient httpClient = new HttpClient();
                var headers = httpClient.DefaultRequestHeaders;
                headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 6.2; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
                // 对要post的数据进行编码
                var content = new FormUrlEncodedContent(new Dictionary<string, string>() {
                    { "id", gameid},
                    { "user", name},
                    { "score", mark},
                    { "words", words}
                });
                // post请求
                HttpResponseMessage response = await httpClient.PostAsync(postUrl, content);
                // 得到返回信息
                update.Text = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                status.Text = response.StatusCode + " " + response.ReasonPhrase + Environment.NewLine;
                Get(Convert.ToInt32(gameid), 10);
            }
            catch (HttpRequestException hre)
            {
                status.Text = hre.ToString();
            }
            catch (Exception ex)
            {
                status.Text = ex.ToString();
            }
        }

    }
    class Record
    {
        public String User { get; set; }
        public String Score { get; set; }
        public String Words { get; set; }
    }
}
