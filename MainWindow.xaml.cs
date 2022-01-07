using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using SalaFitnessModel;
using System.Data;

namespace Aplicatie_dektop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
   
    public partial class MainWindow : Window
    {
        enum ActionState
        {
            New,
            Edit,
            Delete,
            Nothing
        }

        ActionState action = ActionState.Nothing;
        SalaFitnessEntitiesModel ctx = new SalaFitnessEntitiesModel();
        CollectionViewSource clasaVSource;
        CollectionViewSource abonamentVSource;
        CollectionViewSource antrenorVSource;
        CollectionViewSource clientVSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            clasaVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clasaViewSource")));
            clasaVSource.Source = ctx.Clasas.Local;
            ctx.Clasas.Load();

            abonamentVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("abonamentViewSource")));
            abonamentVSource.Source = ctx.Abonaments.Local;
            ctx.Abonaments.Load();
            cmbclasaIdab.ItemsSource = ctx.Clasas.Local;
            //cmbclasaIdab.DisplayMemberPath = "ClasaId";
            cmbclasaIdab.SelectedValuePath = "ClasaId";


            clientVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientViewSource")));
            clientVSource.Source = ctx.Clients.Local;
            ctx.Clients.Load();
            cmbabonamentId.ItemsSource = ctx.Abonaments.Local;
            //cmbabonamentId.DisplayMemberPath = "AbonamentId";
            cmbabonamentId.SelectedValuePath = "AbonamentId";

            antrenorVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("antrenorViewSource")));
            antrenorVSource.Source = ctx.Antrenors.Local;
            ctx.Antrenors.Load();
            cmbclasaId.ItemsSource = ctx.Clasas.Local;
          //  cmbclasaId.DisplayMemberPath = "ClasaId";
            cmbclasaId.SelectedValuePath = "ClasaId";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }
     
        private void btnNext1_Click(object sender, RoutedEventArgs e)
        {
            clasaVSource.View.MoveCurrentToNext();
        }
        private void btnPrevious1_Click(object sender, RoutedEventArgs e)
        {
            clasaVSource.View.MoveCurrentToPrevious();
        }
        private void btnNext2_Click(object sender, RoutedEventArgs e)
        {
            antrenorVSource.View.MoveCurrentToNext();
        }
        private void btnPrevious2_Click(object sender, RoutedEventArgs e)
        {
            antrenorVSource.View.MoveCurrentToPrevious();
        }
        private void btnNext3_Click(object sender, RoutedEventArgs e)
        {
            clientVSource.View.MoveCurrentToNext();
        }
        private void btnPrevious3_Click(object sender, RoutedEventArgs e)
        {
            clientVSource.View.MoveCurrentToPrevious();
        }

        private void btnNext4_Click(object sender, RoutedEventArgs e)
        {
            abonamentVSource.View.MoveCurrentToNext();
        }
        private void btnPrevious4_Click(object sender, RoutedEventArgs e)
        {
            abonamentVSource.View.MoveCurrentToPrevious();
        }
        private void SaveClienti()
        {
            Client client = null;
            if (action == ActionState.New)
            {
                try
                {
                    client = new Client()
                    {
                        Numar_telefon = numar_telefonTextBox1.Text.Trim(),
                        Nume = numeTextBox3.Text.Trim(),
                        Prenume = prenumeTextBox1.Text.Trim()
                    };

                    ctx.Clients.Add(client);
                    clientVSource.View.Refresh();

                    ctx.SaveChanges();
                }

                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            if (action == ActionState.Edit)
            {
                try
                {
                    client = (Client)clientiDataGrid.SelectedItem;
                    client.Numar_telefon = numar_telefonTextBox1.Text.Trim();
                    client.Nume = numeTextBox3.Text.Trim();
                    client.Prenume = prenumeTextBox1.Text.Trim();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    client = (Client)clientiDataGrid.SelectedItem;
                    ctx.Clients.Remove(client);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                clientVSource.View.Refresh();
            }
        }

        private void SaveAbonamente()
        {
            Abonament abonament = null;
            if (action == ActionState.New)
            {
                try
                {
                    abonament = new Abonament()
                    {

                        
                        Nume = numeTextBox4.Text.Trim(),
                        Pret = pretTextBox4.Text.Trim(),
                        Valabilitate = valabilitateTextBox4.Text.Trim(),

                    };

                    ctx.Abonaments.Add(abonament);
                    abonamentVSource.View.Refresh();

                    ctx.SaveChanges();
                }

                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            if (action == ActionState.Edit)
            {
                try
                {
                    abonament = (Abonament)abonamenteDataGrid.SelectedItem;
                    abonament.Pret = pretTextBox4.Text.Trim();
                    abonament.Valabilitate = valabilitateTextBox4.Text.Trim();
                    abonament.Nume = numeTextBox4.Text.Trim();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    abonament = (Abonament)abonamenteDataGrid.SelectedItem;
                    ctx.Abonaments.Remove(abonament);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                abonamentVSource.View.Refresh();
            }
        }

        private void SaveClase()
        {
            Clasa clasa = null;
            if (action == ActionState.New)
            {
                try
                {
                    clasa = new Clasa()
                    {
                        Durata = durataTextBox.Text.Trim(),
                        Nume = numeTextBox1.Text.Trim(),
                        Ora_incepere = ora_incepereTextBox.Text.Trim(),
                        Program = programTextBox.Text.Trim()
                    };

                    ctx.Clasas.Add(clasa);
                    clasaVSource.View.Refresh();

                    ctx.SaveChanges();
                }

                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            if (action == ActionState.Edit)
            {
                try
                {
                    clasa = (Clasa)claseDataGrid.SelectedItem;
                    clasa.Durata = durataTextBox.Text.Trim();
                    clasa.Nume = numeTextBox1.Text.Trim();
                    clasa.Ora_incepere = ora_incepereTextBox.Text.Trim();
                    clasa.Program = programTextBox.Text.Trim();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    clasa = (Clasa)claseDataGrid.SelectedItem;
                    ctx.Clasas.Remove(clasa);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                clasaVSource.View.Refresh();
            }
        }

        private void SaveAntrenori()
        {
            Antrenor antrenor = null;
            if (action == ActionState.New)
            {
                try
                {
                    antrenor = new Antrenor()
                    {

                        Numar_telefon = numar_telefonTextBox.Text.Trim(),
                        Nume = numeTextBox2.Text.Trim(),
                        Prenume = prenumeTextBox.Text.Trim()
                    };

                    ctx.Antrenors.Add(antrenor);
                    antrenorVSource.View.Refresh();

                    ctx.SaveChanges();
                }

                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            if (action == ActionState.Edit)
            {
                try
                {
                    antrenor = (Antrenor)antrenoriDataGrid.SelectedItem;
                    antrenor.Numar_telefon = numar_telefonTextBox.Text.Trim();
                    antrenor.Nume = numeTextBox2.Text.Trim();
                    antrenor.Prenume = prenumeTextBox.Text.Trim();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    antrenor = (Antrenor)antrenoriDataGrid.SelectedItem;
                    ctx.Antrenors.Remove(antrenor);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                antrenorVSource.View.Refresh();
            }
        }

        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }

        private void ReInitialize()
        {
            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlSalaFitness.SelectedItem as TabItem;
            switch (ti.Header)
            {
                case "Clienti":
                    SaveClienti();
                    break;
                case "Antrenori":
                    SaveAntrenori();
                    break;
                case "Abonamente":
                    SaveAbonamente();
                    break;
                case "Clase":
                    SaveClase();
                    break;
            }
            ReInitialize();
        }

       
    }
}
