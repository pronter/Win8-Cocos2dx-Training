using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Windows.Data.Xml.Dom;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text;


// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Homework_07
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<phone_informaiton> rec;
        private string getUrl = "http://www.096.me/api.php?phone={0}&mode=xml";
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Get(telephone.Text);
        }

        private async void Get(string phoneNumber)
        {
            try
            {
                status.Text = "Waiting for response ...";
                result.Visibility = Visibility.Visible;
                HttpClient httpClient = new HttpClient();
                var headers = httpClient.DefaultRequestHeaders;
                // 添加HTTP头
                headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 6.2; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
                // 根据用户输入的gameid，number来进行字符串格式化，变量getUrl在上面可以找到
                // 自己采用自己喜欢的方法，反正得到http://222.200.185.43:8000/rank/getScore/?id=gameid&num=number这url就行
                string url = string.Format(getUrl, phoneNumber);
                // 使用get方法请求url
                HttpResponseMessage response = await httpClient.GetAsync(url);
                // 响应失败将抛出异常
                response.EnsureSuccessStatusCode();
                //转码
                Byte[] bytes = await response.Content.ReadAsByteArrayAsync();
                Encoding readAsGbk = Encoding.GetEncoding("GBK");
                string xml_text = readAsGbk.GetString(bytes, 0, bytes.Length);
                // 获取返回内容
                //  string rescontent = await response.Content.ReadAsStringAsync();
                XmlDocument xmlDoc = new XmlDocument();
                // 对返回回来的xml进行解析
                xmlDoc.LoadXml(xml_text);
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList telenumber = root.SelectNodes("/smartresult/product/phonenum");
                XmlNodeList zone = root.SelectNodes("/smartresult/product/location");
                rec = new List<phone_informaiton>();
                for (int i = 0; i < telenumber.Length; i++)
                {
                    string temp = zone[i].InnerText, postcod = "", typ = "", position = "";
                    int location = 1, pos = 0, ty = 0, count = 0;
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (temp[j] == ',')
                        {
                            location = 0;
                            if (count == 0)
                            {
                                pos = 1;
                                count = 1;
                            }
                            else
                            {
                                pos = 0;
                            }
                            j++;
                        }
                        if (temp[j] == '：')
                        {
                            pos = 0;
                            ty = 1;
                            j++;
                        }
                        if (location == 1)
                            position += temp[j];
                        if (pos == 1)
                            postcod += temp[j];
                        if (ty == 1)
                            typ += temp[j];
                    }
                    rec.Add(new phone_informaiton() { phone_number = telenumber[i].InnerText + '\n' + '\n', zone = position + '\n'});
                }
                result.ItemsSource = rec;
            }
            catch (HttpRequestException hre)
            {
                status.Text = hre.ToString();
            }
            catch (Exception ex)
            {
                status.Text = ex.ToString();
                status.Text = "Please write in the right telenumber!";
                result.Visibility = Visibility.Collapsed;
            }
        }
    }
}


class phone_informaiton
{
    public string phone_number { get; set; }
    public string zone { get; set; }
}
