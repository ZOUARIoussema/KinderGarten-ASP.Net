using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
	public class NoticeService
	{
        HttpClient httpClient;
        public NoticeService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));
        }
        public IEnumerable<Notice> getNoticeByScore()
        {

            var response = httpClient.GetAsync(Statics.baseAddress + "parent/GetNoticesByScore").Result;



            if (response.IsSuccessStatusCode)
            {
                var not = response.Content.ReadAsAsync<IEnumerable<Notice>>().Result;
                return not;

            }

            return (new List<Notice>());

        }
        public bool deleteNoticeById(int id)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "parent/deleteNotice/" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Notice getNoticeById(int id)
        {
            Notice Notice = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getNoticeById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var n = response.Content.ReadAsAsync<Notice>().Result;
                return n;
            }
            return Notice;
        }


    }
}
