﻿using System;
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
        public async Task<List<Perso>> GetPersons()
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
                await azureDatabase.SyncContext.PushAsync();

                if (pullData)
                {

                    await azureSyncTable.PullAsync("allPersos", azureSyncTable.CreateQuery()); // query ID is used for incremental sync
                }

            }

            catch (Exception e)
            {
                Debug.WriteLine(e);


            }
        }

    }
}

