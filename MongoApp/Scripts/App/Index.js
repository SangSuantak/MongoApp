var IndexHandler = function () {
    this.txtDeptName = $("#txtDeptName");
    this.txtHodId = $("#txtHodId");
    this.btnSubmit = $("#btnSubmit");
    this.divMessage = $("#divMessage");
    this.divDepartments = $("#divDepartments");
};

IndexHandler.prototype.BindEvents = function () {
    var h = this;
    h.btnSubmit.click(function (e) {
        e.preventDefault();
        h.CreateDepartment();
    });
    h.FetchDepartments();
};

IndexHandler.prototype.CreateDepartment = function () {
    var createDeptUrl = rootUrl + "Home/CreateDepartment",
        postData = null,
        DTO = null;

    postData = {
        DepartmentName: txtDeptName.val(),
        HeadOfDepartmentId: txtHodId.val()
    };

    DTO = { "objDept": postData };

    $.ajax({
        type: "POST",
        url: createDeptUrl,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(DTO),
        success: function (data) {
            if (data.IsDataInserted) {
                divMessage.html("Department Created").show("slow");
            }
            else {
                divMessage.html(data.Message);
            }
        }
    });
};

IndexHandler.prototype.FetchDepartments = function () {
    var h = this,
        url = rootUrl + "Home/FetchDepartments";

    $.post(url, function (data) {
        if (data.IsDataFetched) {
            var markup = "";            
            h.divDepartments.html(data.obj);
        }
    });
};




var iHandler;
$(function () {
    iHandler = new IndexHandler();
    iHandler.BindEvents();
});