using CarLotModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

namespace Masina_Inmatriculare
{
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        CarLotEntitiesModel ctx = new CarLotEntitiesModel();
        CollectionViewSource carVSource;
        CollectionViewSource permissionVSource;
        CollectionViewSource carregistrationVSource;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            carVSource =
((System.Windows.Data.CollectionViewSource)(this.FindResource("carViewSource")));
            carVSource.Source = ctx.Car.Local;
            ctx.Car.Load();
            permissionVSource =
((System.Windows.Data.CollectionViewSource)(this.FindResource("permissionViewSource")));
            permissionVSource.Source = ctx.Permission.Local;
            ctx.Permission.Load();
            carregistrationVSource =
((System.Windows.Data.CollectionViewSource)(this.FindResource("carregistrationViewSource")));

            //carregistrationVSource.Source = ctx.Registration.Local;
            ctx.Registration.Load();
            ctx.Permission.Load();
            cmbCar.ItemsSource = ctx.Car.Local;
            //cmbCar.DisplayMemberPath = "Class";
            cmbCar.SelectedValuePath = "Car_Id";
            cmbPermission.ItemsSource = ctx.Permission.Local;
            //cmbPermission.DisplayMemberPath = "Worker_Id";
            cmbPermission.SelectedValuePath = "Perm_Id";

            System.Windows.Data.CollectionViewSource carViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("carViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // carViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource permissionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("permissionViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // permissionViewSource.Source = [generic data source]
            BindDataGrid();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
            
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
            BindingOperations.ClearBinding(colorTextBox, TextBox.TextProperty);
            BindingOperations.ClearBinding(modelTextBox, TextBox.TextProperty);
            SetValidationBinding();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            carVSource.View.MoveCurrentToNext();
        }
        private void btnNextP_Click(object sender, RoutedEventArgs e)
        {
            permissionVSource.View.MoveCurrentToNext();
        }
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            carVSource.View.MoveCurrentToPrevious();
        }
        private void btnPrevP_Click(object sender, RoutedEventArgs e)
        {
            permissionVSource.View.MoveCurrentToPrevious();
        }
        private void SaveCar()
        {
            Car car = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Car entity
                    car = new Car()
                    {
                        Class = classTextBox.Text.Trim(),
                        Manufacturer = manufacturerTextBox.Text.Trim(),
                        Model = modelTextBox.Text.Trim(),
                        Year = int.Parse(yearTextBox.Text.Trim()),
                        Color = colorTextBox.Text.Trim(),
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Car.Add(car);
                    carVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
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
                    car = (Car)carDataGrid.SelectedItem;
                    car.Class = classTextBox.Text.Trim();
                    car.Manufacturer = manufacturerTextBox.Text.Trim();
                    car.Model = modelTextBox.Text.Trim();
                    car.Year = int.Parse(yearTextBox.Text.Trim());
                    car.Color = colorTextBox.Text.Trim();
                    //salvam modificarile
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
                    car = (Car)carDataGrid.SelectedItem;
                    ctx.Car.Remove(car);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                carVSource.View.Refresh();
            }

        }
        private void SavePermission()
        {
            Permission permission = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Permission entity
                    permission = new Permission()
                    {
                        Car_Registration_Documents = car_Registration_DocumentsTextBox.Text.Trim(),
                        Phone_No = int.Parse(phone_NoTextBox.Text.Trim()),
                        Worker_Id = worker_IdTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Permission.Add(permission);
                    permissionVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
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
                    permission = (Permission)permissionDataGrid.SelectedItem;
                    permission.Car_Registration_Documents = car_Registration_DocumentsTextBox.Text.Trim();
                    permission.Phone_No = int.Parse(phone_NoTextBox.Text.Trim());
                    permission.Worker_Id = worker_IdTextBox.Text.Trim();
                    //salvam modificarile
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
                    permission = (Permission)permissionDataGrid.SelectedItem;
                    ctx.Permission.Remove(permission);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                permissionVSource.View.Refresh();
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
            TabItem ti = tbCtrlAutoLot.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Car":
                    SaveCar();
                    break;
                case "Permission":
                    SavePermission();
                    break;
                case "Registration":
                    break;
            }
            ReInitialize();
        }
        private void SaveRegistration()
        {
            Registration registration = null;
            if (action == ActionState.New)
            {
                try
                {
                    Car car = (Car)cmbCar.SelectedItem;
                    Permission permission = (Permission)cmbPermission.SelectedItem;
                    //instantiem Order entity
                    registration = new Registration()
                    {

                        Car_Id = car.Car_Id,
                        Perm_Id = permission.Perm_Id
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Registration.Add(registration);
                    //salvam modificarile
                    ctx.SaveChanges();
                    BindDataGrid();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
if (action == ActionState.Edit)
            {
                dynamic selectedOrder = registrationDataGrid.SelectedItem;
                try
                {
                    int curr_id = selectedOrder.OrderId;
                    var editedOrder = ctx.Registration.FirstOrDefault(s => s.Reg_Id == curr_id);
                    if (editedOrder != null)
                    {
                        editedOrder.Car_Id = Int32.Parse(cmbCar.SelectedValue.ToString());
                        editedOrder.Perm_Id = Convert.ToInt32(cmbPermission.SelectedValue.ToString());
                        //salvam modificarile
                        ctx.SaveChanges();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                BindDataGrid();
                // pozitionarea pe item-ul curent
                carregistrationVSource.View.MoveCurrentTo(selectedOrder);
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    dynamic selectedRegistration = registrationDataGrid.SelectedItem;
                    int curr_id = selectedRegistration.Reg_Id;
                    var deletedRegistration = ctx.Registration.FirstOrDefault(s => s.Reg_Id == curr_id);
                    if (deletedRegistration != null)
                    {
                        ctx.Registration.Remove(deletedRegistration);
                        ctx.SaveChanges();
                        MessageBox.Show("Registration Deleted Successfully", "Message");
                        BindDataGrid();
                    }
                }


                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void BindDataGrid()
        {
            var queryOrder = from reg in ctx.Registration
                             join car in ctx.Car on reg.Car_Id equals
                             car.Car_Id
                             join perm in ctx.Permission on reg.Perm_Id
                 equals perm.Perm_Id
                             select new
                             {
                                 reg.Reg_Id,
                                 reg.Perm_Id,
                                 reg.Car_Id,
                                 car.Class,
                                 car.Year,
                                 perm.Phone_No,
                                 perm.Worker_Id
                             };
            carregistrationVSource.Source = queryOrder.ToList();
        }
        private void SetValidationBinding()
        {
            Binding colorValidationBinding = new Binding();
            colorValidationBinding.Source = carVSource;
            colorValidationBinding.Path = new PropertyPath("Color");
            colorValidationBinding.NotifyOnValidationError = true;
            colorValidationBinding.Mode = BindingMode.TwoWay;
            colorValidationBinding.UpdateSourceTrigger =
           UpdateSourceTrigger.PropertyChanged;
            //string required
            colorValidationBinding.ValidationRules.Add(new StringNotEmpty());
            colorTextBox.SetBinding(TextBox.TextProperty, colorValidationBinding);
            Binding modelValidationBinding = new Binding();
            modelValidationBinding.Source = carVSource;
            modelValidationBinding.Path = new PropertyPath("Model");
            modelValidationBinding.NotifyOnValidationError = true;
            modelValidationBinding.Mode = BindingMode.TwoWay;
            modelValidationBinding.UpdateSourceTrigger =
           UpdateSourceTrigger.PropertyChanged;
            //string min length validator
            modelValidationBinding.ValidationRules.Add(new StringMinLengthValidator());
            modelTextBox.SetBinding(TextBox.TextProperty,
           modelValidationBinding); //setare binding nou
        }

    }
}

