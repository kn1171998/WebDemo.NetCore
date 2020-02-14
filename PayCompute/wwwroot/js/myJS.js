var isEmpty = function (data) {
    if (typeof (data) === 'object') {
        if (JSON.stringify(data) === '{}' || JSON.stringify(data) === '[]') {
            return true;
        } else if (!data) {
            return true;
        }
        return false;
    } else if (typeof (data) === 'string') {
        if (!data.trim()) {
            return true;
        }
        return false;
    } else if (typeof (data) === 'undefined') {
        return true;
    } else {
        return false;
    }
}

var callGetData =
    function () {
        $('#listEMP').html('');
        var dept = $('#dept').val();
        $.ajax({
            url: "/TimekeepingEMP/GetData",
            data: { idDept: dept },
            dataType: "Json",
            type: "GET",
            success: function (response) {
                if (!isEmpty(response)) {
                    if (!response) {
                        var td = "<div style='font-size: 20px' class='text-white text-justify bd-highlight'>This Department has Timekeeping</div>";
                        $('#listEMP').append(td);
                    } else {
                        $(response).each(function (i, e) {
                            var td =
                                "<tr><td>" + e.employeename +
                                "</td><td>" + e.phone + "</td><td><select disabled class='form-control furlough' name='furlough_" + e.employeeid + "' id='furlough'>" +
                                "<option value='1'>Yes</option>" +
                                "<option value='0'>No</option></select></td><td><select class='form-control status' name='status_" + e.employeeid + "' id='status'>" +
                                "<option value='1'>Present</option>" +
                                "<option value='0'>Absent</option></select></td><td>" +
                                "<input type='text' class='form-control' name='reason_" + e.employeeid + "' id='reason'/></td></tr>";
                            $('#listEMP').append(td);
                        });
                    }
                }
            }
        })
    }
var callGetDataIndex_Timekeeping =
    function () {
        $('#listEMP').html('');
        var datepick = $('#datepicker').val();
        var now = new Date();
        var dm = now.getFullYear() + '-' + now.getUTCMonth() + '-' + now.getDate();
        var dept = $('#dept').val();
        if (datepick <= dm && !isEmpty(dept)) {
            $.ajax({
                url: "/TimekeepingEMP/GetData_Index",
                data: { day: datepick, idDept: dept },
                dataType: "Json",
                type: "GET",
                success: function (response) {
                    if (!isEmpty(response)) {
                        if (!response) {
                            var td = "<div style='font-size: 20px' class='text-white text-justify bd-highlight'>This Department has not Timekeeping</div>";
                            $('#listEMP').append(td);
                        } else {
                            $(response).each(function (i, e) {
                                var status = e.status ? "Present" : "Absent";
                                var furlough = "";
                                if (!e.status) {
                                    furlough = e.furlough ? "Yes" : "No";
                                }
                                var td =
                                    "<tr><td>" + e.employeename + "</td>" +
                                    "<td>" + e.phone + "</td>" +
                                    "<td>" + furlough + "</td>" +
                                    "<td>" + status + "</td><td>" +
                                    "<input disabled type='text' class='form-control' value='" + e.reason + "'/></td></tr>";
                                $('#listEMP').append(td);
                            });
                        }
                    }
                }
            })
        }
    }