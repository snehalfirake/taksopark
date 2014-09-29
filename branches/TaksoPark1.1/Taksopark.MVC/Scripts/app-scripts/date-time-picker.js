//jQuery('#datetimepicker').datetimepicker();

jQuery('#datetimepicker').datetimepicker({
    lang: 'de',
    i18n: {
        de: {
            months: [
             'Januar', 'Februar', 'März', 'April',
             'Mai', 'Juni', 'Juli', 'August',
             'September', 'Oktober', 'November', 'Dezember',
            ],
            dayOfWeek: [
             "So.", "Mo", "Di", "Mi",
             "Do", "Fr", "Sa.",
            ]
        }
    },
    timepicker: false,
    format: 'd.m.Y'
});