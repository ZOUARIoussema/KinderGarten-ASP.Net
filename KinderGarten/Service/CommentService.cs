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
	public class CommentService
	{
        HttpClient httpClient;
        public CommentService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));
        }
        public Boolean Add(Comment comment)
        {
            try
            {
                
                var APIResponse = httpClient.PostAsJsonAsync<Comment>(Statics.baseAddress + "parent/addComment",
                    comment).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Comment comment)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Comment>(Statics.baseAddress + "parent/updateComment",
                 comment).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Comment> getAllComment()
        {

            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getAllComment").Result;



            if (response.IsSuccessStatusCode)
            {
                var com = response.Content.ReadAsAsync<IEnumerable<Comment>>().Result;
                return com;

            }

            return (new List<Comment>());

        }

        public bool deleteCommentById(int id)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "parent/deleteComment/" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Comment getCommentById(int id)
        {
            Comment Comment = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getCommentById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var c = response.Content.ReadAsAsync<Comment>().Result;
                return c;
            }
            return Comment;
        }

    }
}
