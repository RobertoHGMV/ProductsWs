using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProductsWs.UI.Helpers
{
    public static class FormHelpers
    {
        public static MessageBoxResult MessageQuestion(string message)
        {
            return MessageBox.Show(message, "Mensagem do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public static void MessageSuccess(string message = "Operação realizada com sucesso!")
        {
            MessageBox.Show(message, "Mensagem do Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void MessageError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Mensagem do Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static bool UserConfirm(string message)
        {
            return MessageBoxResult.Yes.Equals(MessageQuestion(message));
        }

        public static void SetHeader(this DataGrid grid, string columnName, string newColumnName)
        {
            var column = grid.Columns.FirstOrDefault(c => columnName.Equals(c.Header.ToString()));

            if (column != null)
                column.Header = newColumnName;
        }

        public static void SetVisible(this DataGrid grid, string columnName, bool visible = false)
        {
            var column = grid.Columns.FirstOrDefault(c => columnName.Equals(c.Header.ToString()));

            if (column is null) return;

            column.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
