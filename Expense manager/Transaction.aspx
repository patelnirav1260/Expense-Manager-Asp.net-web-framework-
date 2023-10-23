<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="Expense_manager.Transaction1" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Transactions</h2>
            <div class="row">
                <div class="col-md-8">
                    <asp:GridView ID="TransactionGridView" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="False" DataKeyNames="TransactionID"
                        OnRowEditing="TransactionGridView_RowEditing" OnRowCancelingEdit="TransactionGridView_RowCancelingEdit"
                        OnRowUpdating="TransactionGridView_RowUpdating" OnRowDeleting="TransactionGridView_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" ReadOnly="True" SortExpression="TransactionID" />
                            <asp:TemplateField HeaderText="Description">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' CssClass="form-control" placeholder="Description"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAmount" runat="server" Text='<%# Bind("Amount") %>' CssClass="form-control" placeholder="Amount"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDate" runat="server" Text='<%# Bind("Date", "{0:dd/MM/yyyy}") %>' CssClass="form-control datepicker" placeholder="MM/dd/yyyy"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlEditCategory" runat="server" DataTextField="CategoryName" DataValueField="CategoryID"
                                        CssClass="form-control">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category.CategoryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                    <br />
                    <asp:Button ID="btnAddTransaction" runat="server" Text="Add Transaction" OnClick="btnAdd_Click" CssClass="btn btn-success" />
                    <br />
                    <asp:Panel ID="pnlNewTransaction" runat="server" Visible="false">
                        <h3>New Transaction</h3>
                        <asp:TextBox ID="txtNewDescription" runat="server" CssClass="form-control" placeholder="Description"></asp:TextBox>
                        <asp:TextBox ID="txtNewAmount" runat="server" CssClass="form-control mt-3" placeholder="Amount"></asp:TextBox>
                        <asp:TextBox ID="txtNewDate" runat="server" CssClass="form-control mt-3 datepicker" placeholder="dd/mm/yyyy"></asp:TextBox>
                        <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="CategoryName" DataValueField="CategoryID"
                            CssClass="form-control mt-3">
                        </asp:DropDownList>
                        <br />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAddTransaction_Click" CssClass="btn btn-primary mt-3" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger mt-2" />
                    </asp:Panel>
                </div>
            </div>
            <div class="row mt-5">
                <div class="col-md-12">
                    <h3>All Transactions</h3>
                    <div class="card-columns">
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
  