$(document).ready(function () {
    $(".addVote").click(function () {
        let teacherId = $(this).data("teacherid");
        $.post(
            "vote/add",
            { teacherId },
            function (response) {
                if (response === "Success")
                    alert("Дякуємо за Ваш голос!");
                else
                    alert("Сталась помилка або Ви більше не можете проголосувати!");

                location.reload();
            },
        );
    });

    $(".removeVote").click(function () {
        let teacherId = $(this).data("teacherid");
        $.post(
            "vote/remove",
            { teacherId },
            function (response) {
                if (response === "Success")
                    alert("Голос видалений!");
                else
                    alert("Сталась помилка!");

                location.reload();
            },
        );
    });
});