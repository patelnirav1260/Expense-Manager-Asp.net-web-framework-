<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Expense_manager.Categories" MasterPageFile="~/Site1.Master" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row">
                <div class="col-md-8">
                    <h2>Categories</h2>
                    <asp:GridView ID="CategoryGridView" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="False" DataKeyNames="CategoryID"
                        OnRowEditing="CategoryGridView_RowEditing" OnRowCancelingEdit="CategoryGridView_RowCancelingEdit"
                        OnRowUpdating="CategoryGridView_RowUpdating" OnRowDeleting="CategoryGridView_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="CategoryID" HeaderText="Category ID" ReadOnly="True" SortExpression="CategoryID" />
                            <asp:TemplateField HeaderText="Category Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Bind("CategoryName") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCategoryName" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-4">
                    <h3>Options</h3>
                    <br />
                    <asp:Button ID="btnAddCategoryHeader" runat="server" Text="Add Category" OnClick="btnNewCategory_Click" CssClass="btn btn-success" />
                    <br />
                    <asp:Panel ID="pnlNewCategory" runat="server" Visible="false">
                        <h3>New Category</h3>
                        <asp:TextBox ID="txtNewCategory" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" OnClick="btnAddCategory_Click" CssClass="btn btn-primary mt-3" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger mt-2" />
                    </asp:Panel>
                </div>
            </div>

            <div class="row mt-5">
                <div class="col-md-12">
                    <h2>All Categories</h2>
              
                    <asp:Repeater ID="CategoryRepeater" runat="server">
                        <ItemTemplate>
                            <div><%# Eval("CategoryName") %></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </form>
   </asp:Content>