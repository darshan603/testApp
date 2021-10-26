var dataTable;

$(document).ready(function () {
  loadDataTable();
});

function loadDataTable() {
  dataTable = $("#tblData").DataTable({
    ajax: {
          url: "/Home/GetAllCustList",
    },
    columns: [
        { data: "invNo", autoWidth: true },
        { data: "customerName", autoWidth: true },
        { data: "address", autoWidth: true },
        { data: "tel", autoWidth: true },
      {
          data: "salesID",
        render: function (data) {
          return `
                            <div class="text-center">
                                <a href="/Home/Details/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                
                            </div>
                           `;
        },
        autoWidth: true,
      },
    ],
  });
}


