using ProductsWs.UI.Helpers;
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

namespace ProductsWs.UI
{
    public partial class MainWindow : Window
    {
        localhost.ProductWS ProductWS;

        public MainWindow()
        {
            InitializeComponent();

            ProductWS = new localhost.ProductWS();
            FormatControls();
            SignEvents();
        }

        private void SignEvents()
        {
            Loaded += MainWindow_Loaded;
            gridProducts.SelectionChanged += GridProducts_SelectionChanged;
            txtQuantity.TextChanged += Values_TextChanged;
            txtPrice.TextChanged += Values_TextChanged;
        }

        private void FillControls()
        {
            var model = gridProducts.SelectedItem as localhost.ProductModel;

            if (model is null) return;

            txtItemCode.Text = model.ItemCode;
            txtItemName.Text = model.ItemName;
            txtQuantity.Text = decimal.Zero.Equals(model.Quantity) ? string.Empty : model.Quantity.ToString();
            txtPrice.Text = decimal.Zero.Equals(model.Price) ? string.Empty : model.Price.ToString();
            txtTotal.Text = decimal.Zero.Equals(model.Total) ? string.Empty : model.Total.ToString();
        }

        private void FillGrid()
        {
            gridProducts.ItemsSource = ProductWS.GetAll();
            FormatGrid();
        }

        private void FormatGrid()
        {
            if (gridProducts.ItemsSource == null)
                gridProducts.ItemsSource = new List<localhost.ProductModel>();

            gridProducts.SetHeader("ItemCode", "Cód. Item");
            gridProducts.SetHeader("ItemName", "Descrição");
            gridProducts.SetHeader("Quantity", "Quantidade");
            gridProducts.SetHeader("Price", "Preço");

            gridProducts.IsReadOnly = true;
            gridProducts.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        private void FormatControls()
        {
            txtTotal.IsReadOnly = true;
        }

        private void ClearControls()
        {
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        private void FillClass(localhost.ProductModel model)
        {
            model.ItemCode = txtItemCode.Text;
            model.ItemName = txtItemName.Text;
            model.Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToInt32(txtQuantity.Text);
            model.Price = string.IsNullOrEmpty(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text);
            model.Total = string.IsNullOrEmpty(txtTotal.Text) ? 0 : Convert.ToDecimal(txtTotal.Text);
        }

        private void SetTotal()
        {
            var quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToInt32(txtQuantity.Text);
            var price = string.IsNullOrEmpty(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text);
            txtTotal.Text = (quantity * price).ToString();
        }

        private void Add()
        {
            var model = new localhost.ProductModel();
            FillClass(model);
            ProductWS.Add(model);
        }

        private void Update()
        {
            var model = gridProducts.SelectedItem as localhost.ProductModel;

            if (model is null) return;

            FillClass(model);
            ProductWS.Update(model);
        }

        private void Delete()
        {
            var model = gridProducts.SelectedItem as localhost.ProductModel;

            if (model != null)
                ProductWS.Delete(model.ItemCode);
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearControls();
            }
            catch (Exception ex)
            {
                FormHelpers.MessageError(ex);
            }
        }

        private void BtnList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillGrid();
            }
            catch (Exception ex)
            {
                FormHelpers.MessageError(ex);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Add();
                FillGrid();
                FormHelpers.MessageSuccess();
            }
            catch (Exception ex)
            {
                FormHelpers.MessageError(ex);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Update();
                FillGrid();
                FormHelpers.MessageSuccess();
            }
            catch (Exception ex)
            {
                FormHelpers.MessageError(ex);
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!FormHelpers.UserConfirm("Deseja realmente remover o item selecionado?")) return;

                Delete();
                FillGrid();
                FormHelpers.MessageSuccess();
            }
            catch (Exception ex)
            {
                FormHelpers.MessageError(ex);
            }
        }

        private void CmdOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FormHelpers.UserConfirm("Deseja fechar aplicação?"))
                    Close();
            }
            catch (Exception ex)
            {
                FormHelpers.MessageError(ex);
            }
        }

        private void GridProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                FillControls();
            }
            catch (Exception ex)
            {
                FormHelpers.MessageError(ex);
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                FormatGrid();
            }
            catch (Exception ex)
            {
                FormHelpers.MessageError(ex);
            }
        }

        private void Values_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SetTotal();
            }
            catch (Exception ex)
            {
                FormHelpers.MessageError(ex);
            }
        }
    }
}
