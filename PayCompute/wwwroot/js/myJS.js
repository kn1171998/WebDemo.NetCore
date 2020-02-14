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
        var datepick = $('#datepicker').val();
        var now = new Date();
        var dm = now.getFullYear() + '-' + now.getUTCMonth() + '-' + now.getDate();
        var dept = $('#dept').val();
        if (datepick <= dm && !isEmpty(dept)) {
            $.ajax({
                url: "/TimekeepingEMP/GetData",
                data: { day: datepick, idDept: dept },
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
    }