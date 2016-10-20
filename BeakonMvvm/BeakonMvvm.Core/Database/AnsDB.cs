using BeakonMvvm.Core.Interfaces;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// Author Gurpreet Dhaliwal
namespace BeakonMvvm.Core.Database
{
    
    public class AnsDB : IAnsDB
    {
        private MobileServiceClient azureDatabase;
        private IMobileServiceSyncTable<Answ> azureSyncTable;
        public AnsDB()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            azureSyncTable = azureDatabase.GetSyncTable<Answ>();
        }

        public async Task<bool> CheckIfExists(Answ location)
        {
            var locations = await azureSyncTable.Where(x => x.Id == location.Id).ToListAsync();
            return locations.Any();
        }

        public async Task<int> DeleteAns(object id)
        {
            await SyncAsync(true);
            var location = await azureSyncTable.Where(x => x.Id == (string)id).ToListAsync();
            if (location.Any())
            {
                await azureSyncTable.DeleteAsync(location.FirstOrDefault());
                await SyncAsync();
                return 1;
            }
            else
            {
                return 0;

            }
        }

        public async Task<List<Answ>> GetAns()
        {

            await SyncAsync(true);
            var locations = await azureSyncTable.ToListAsync();
            return locations;

        }

        public async Task<int> InsertAns(Answ p)
        {

            await SyncAsync(true);
            await azureSyncTable.InsertAsync(p);
            await SyncAsync();
            return 1;
        }
        private async Task SyncAsync(bool pullData = false)
        {
            try
            {
                await azureDatabase.SyncContext.PushAsync();

                if (pullData)
                {

                    await azureSyncTable.PullAsync("allReqs", azureSyncTable.CreateQuery()); // query ID is used for incremental sync
        }

    }

            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }

}

