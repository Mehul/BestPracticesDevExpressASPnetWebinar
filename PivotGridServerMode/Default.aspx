<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="Default.aspx.cs" Inherits="PivotGridServerMode._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>


<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxPivotGrid ID="ASPxPivotGrid2" DataSourceID="LinqServerModeDataSource1" runat="server" Width="100%">
             <Fields>
                    <dx:PivotGridField FieldName="OrderID" Visible="False" Caption="OrderID" DisplayFolder="Order" />
                    <dx:PivotGridField FieldName="Quantity" Area="DataArea" Caption="Quantity" DisplayFolder="Order" />
                    <dx:PivotGridField FieldName="UnitPrice" Area="DataArea" Caption="Unit Price" DisplayFolder="Order" />
                    <dx:PivotGridField Area="DataArea" Caption="Revenue" UnboundExpression="[UnitPrice]*[Quantity]" UnboundType="Object" DisplayFolder="Order" CellFormat-FormatType="Numeric" CellFormat-FormatString="c" /> 
                    <dx:PivotGridField FieldName="Order.Customer.CustomerName" Visible="False" Caption="Customer" DisplayFolder="Customer" />
                    <dx:PivotGridField FieldName="Order.CustomerID" Visible="False" Caption="CustomerID" DisplayFolder="Customer" />
                    <dx:PivotGridField FieldName="Order.OrderDate" Visible="False" Caption="Order Date" DisplayFolder="Order Date" />
                    <dx:PivotGridField FieldName="Order.OrderDate" Area="ColumnArea" Caption="Order Year" GroupInterval="DateYear" DisplayFolder="Order Date" />
                    <dx:PivotGridField FieldName="Order.OrderDate" Visible="False" Area="ColumnArea" Caption="Order Quarter" GroupInterval="DateQuarter" DisplayFolder="Order Date" />
                    <dx:PivotGridField FieldName="Product.ProductName" Area="RowArea" Caption="Product" DisplayFolder="Product" />
                    <dx:PivotGridField FieldName="ProductID" Visible="False" Caption="ProductID" DisplayFolder="Product" />
                    <dx:PivotGridField FieldName="Product.Category.CategoryName" Visible="False" Caption="Category Name" DisplayFolder="Product" />
                    <dx:PivotGridField FieldName="Product.CategoryID" Visible="False" Caption="CategoryID" DisplayFolder="Product" />
                    <dx:PivotGridField FieldName="Order.SalesPerson.SalesPersonName" Area="RowArea" Caption="Sales Person" DisplayFolder="Sales Person" />
                    <dx:PivotGridField FieldName="Order.SalesPersonID" Visible="False" Caption="SalesPersonID" DisplayFolder="Sales Person" />
             </Fields>
    </dx:ASPxPivotGrid>
    <dx:LinqServerModeDataSource ID="LinqServerModeDataSource1" runat="server" ContextTypeName="PivotGridServerMode.DataClasses1DataContext" TableName="Sales">
    </dx:LinqServerModeDataSource>
</asp:Content>