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
   public class FolderMedicalService
    {

        HttpClient httpClient;

        public FolderMedicalService(String accessToken)
        {

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}"," "+accessToken));
        }



        public Boolean Add(FolderMedical folder)
        {

            try
            {


                var APIResponse = httpClient.PostAsJsonAsync<FolderMedical>(Statics.baseAddress + "medical/addFolderMedical/" + folder.ChildId,
                folder).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);


                return true;


            }
            catch
            {
                return false;
            }

            
        }


        public IEnumerable<Child> getAllChild()
        {

            var response = httpClient.GetAsync(Statics.baseAddress + "medical/getAllChild").Result;


            System.Diagnostics.Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                var childs = response.Content.ReadAsAsync<IEnumerable<Child>>().Result;

                return childs;
            }

            return new List<Child>();

        }


        public FolderMedical GetById(int id)
        {

            FolderMedical folderMedical = null;

            var response = httpClient.GetAsync(Statics.baseAddress + "medical/getFoldderMedicalById/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var folder = response.Content.ReadAsAsync<FolderMedical>().Result;

                return folder;
            }


            return folderMedical;

        }

        public bool UpdateFolder(FolderMedical folderMedical)
        {


            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<FolderMedical>(Statics.baseAddress + "medical/updateFolderMedical/" + folderMedical.ChildId,
                 folderMedical).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);

                return true;
            }
            catch
            {
                return false;
            }

        }


        public bool DeleteFolder(int id)
        {

            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "medical/deleteFolderMedical/" + id);

                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool DeleteVaccineFolder(int idF,int ? idV)
        {

            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<FolderMedical>(Statics.baseAddress + "medical/deleteVaccineFolder/"+idF+"/"+idV,new FolderMedical());

                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool AddVaccineFolder(int idF, int? idV)
        {

            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<FolderMedical>(Statics.baseAddress + "medical/addVaccineFolder/" + idF + "/" + idV, new FolderMedical());

                return true;
            }
            catch
            {
                return false;
            }


        }


        public IEnumerable<FolderMedical> GetAll()
        {

            var response = httpClient.GetAsync(Statics.baseAddress + "medical/getAllFolderMedical").Result;

            if (response.IsSuccessStatusCode)
            {
                var folderMedicals = response.Content.ReadAsAsync<IEnumerable<FolderMedical>>().Result;

                return folderMedicals;
            }

            return new List<FolderMedical>();

        }





    }
}
