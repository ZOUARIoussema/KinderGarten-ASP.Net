using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClubService
    { 
  HttpClient httpClient;
    public ClubService()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(Statics.baseAddress);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));
    }
    public Boolean Add(Club club)
    {
        try
        {
            var APIResponse = httpClient.PostAsJsonAsync<Club>(Statics.baseAddress + "admingarten/addClub/",
                club).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
            System.Diagnostics.Debug.WriteLine(APIResponse.Result);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public Club getClubById(int id)
    {
        Club Club = null;
        var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getClubById/" + id).Result;
        if (response.IsSuccessStatusCode)
        {
            var club = response.Content.ReadAsAsync<Club>().Result;
            return club;
        }
        return Club;
    }
    public bool Update(int id, Club club)
    {
        try
        {
            var APIResponse = httpClient.PutAsJsonAsync<Club>(Statics.baseAddress + "admingarten/updateClub/" + id, club).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
            System.Diagnostics.Debug.WriteLine(APIResponse.Result);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool deleteClubById(int id)
    {
        try
        {
            var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "admingarten/deleteClubById/" + id);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public IEnumerable<Club> GetAll()
    {
        var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getAllclub").Result;
        if (response.IsSuccessStatusCode)
        {
            var club = response.Content.ReadAsAsync<IEnumerable<Club>>().Result;
            return club;
        }
        return new List<Club>();
    }
}
}
