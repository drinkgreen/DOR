using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;


namespace DORv3.Helpers
{
    public static class DORHelper
    {
        public static MvcHtmlString DisplayNameFor<TModel, TProperty>(this HtmlHelper<IEnumerable<TModel>> helper, Expression<Func<TModel, TProperty>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            name = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var metadata = ModelMetadataProviders.Current.GetMetadataForProperty(() => Activator.CreateInstance<TModel>(), typeof(TModel), name);
            return new MvcHtmlString(metadata.DisplayName);
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                //var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                var displayAttr = (DisplayAttribute)prop.GetCustomAttribute(typeof(DisplayAttribute));
                var formatAttr = (DisplayFormatAttribute)prop.GetCustomAttribute(typeof(DisplayFormatAttribute));

                dataTable.Columns.Add((displayAttr != null ? displayAttr.Name : prop.Name), "string".GetType());
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)
                {
                    //does the field have a custom DisplayFormatAttribute assigned
                    var formatAttr = (DisplayFormatAttribute)Props[i].GetCustomAttributes(typeof(DisplayFormatAttribute), false).FirstOrDefault();


                    //inserting property values to datatable rows
                    var fieldVal = Props[i].GetValue(item, null);
                    values[i] = (formatAttr != null ? string.Format(formatAttr.DataFormatString,fieldVal): fieldVal);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static DataTable TransposeTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();

            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }

            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }

        //public static DataTable ToDataTableLeft<T>(List<T> items)
        //{
        //    DataTable dataTable = new DataTable(typeof(T).Name);
        //    DataRow row = dataTable.NewRow();
            
        //    dataTable.Columns.Add("Descrip");
            

        //    //Get all the properties
        //    PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (PropertyInfo prop in Props)
        //    {
        //        //Defining type of data column gives proper data table 
        //        var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
        //        var displayAttr = (DisplayAttribute)prop.GetCustomAttribute(typeof(DisplayAttribute));

        //        //Setting Row names as Property names
        //        //dataTable.Columns.Add((displayAttr != null ? displayAttr.Name : prop.Name), type);
        //        //DataRow row = dataTable.NewRow();
        //        row["Descrip"] = (displayAttr != null ? displayAttr.Name : prop.Name);
        //        dataTable.Rows.Add(row);
                
        //        //dataTable.Rows.Add((displayAttr != null ? displayAttr.Name : prop.Name), type);
        //    }
        //    foreach (T item in items)
        //    {
        //        var values = new object[Props.Length];
        //        for (int i = 0; i < Props.Length; i++)
        //        {
        //            //inserting property values to datatable rows
        //            values[i] = Props[i].GetValue(item, null);
        //        }
                
        //        dataTable.Rows.Add(values);
        //    }
        //    //put a breakpoint here and check datatable
        //    return dataTable;
        //}
    }
}