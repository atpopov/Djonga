using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DjongaTracker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection connection;
        
        public MainPage()
        {
            InitializeComponent();

            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            connection.CreateTableAsync<Models>();
            DisplayData();
        }
        
        async public void DisplayData()
        {
            var allValuesList = await GetAllValues(connection);
            Models model = new Models();
            model.PrCount = allValuesList.Last().Count;
            kur.Text = string.Format("{0} g", model.PrCount);
        }
            
        async private void Button_Clicked(object sender, EventArgs e)
        {
            var allValuesList = await GetAllValues(connection);
            Models model = new Models();
            model.PrCount = allValuesList.Last().Count;
            model.Count = model.PrCount + 0.25;
            kur.Text = string.Format("{0} g", model.Count);
            await connection.InsertAsync(model);
            
        }

       async  void Button_Clicked_1(object sender, EventArgs e)
        {

            var allValuesList = await GetAllValues(connection);
            Models model = new Models();
            model.PrCount = allValuesList.Last().Count;
            model.Count = model.PrCount + 0.5;
            kur.Text = string.Format("{0} g", model.Count);
            await connection.InsertAsync(model);
        }

        public async static Task<List<Models>> GetAllValues(SQLiteAsyncConnection connection)
        {
            try
            {
                return await connection.Table<Models>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
