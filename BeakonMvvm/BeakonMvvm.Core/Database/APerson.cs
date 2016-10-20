using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Platform;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Diagnostics;
using BeakonMvvm.Core.Interfaces;

namespace BeakonMvvm.Core.Database
{
    public class APerson : IAPerson
    {
        private MobileServiceClient azureDatabase;
        private IMobileServiceSyncTable<Perso> azureSyncTable;
        public APerson()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            azureSyncTable = azureDatabase.GetSyncTable<Perso>();
        }

        public async Task<bool> CheckIfExists(Perso location)
        {
            var locations = await azureSyncTable.Where(x => x.pFirstname == location.pFirstname || x.Id == location.Id).ToListAsync();
            return locations.Any();
        }

        public async Task<int> DeletePerson(object id)
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

        public async Task<IEnumerable<Perso>> GetPersons()
        {

            await SyncAsync(true);
            var locations = await azureSyncTable.ToListAsync();
            return locations;

        }

        public async Task<int> InsertPerson(Perso p)
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


                if (pullData)
                {
                    await azureSyncTable.PullAsync("allPersos", azureSyncTable.CreateQuery()); // query ID is used for incremental sync
            await azureDatabase.SyncContext.PushAsync();
        }
    }

            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

    }
}
