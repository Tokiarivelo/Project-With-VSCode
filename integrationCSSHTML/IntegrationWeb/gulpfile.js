// Sass configuration
var gulp = require('gulp');

// var sass = require('gulp-sass');
// gulp.task('sass', function (cb) {
//     gulp.src('wwwroot/css/*.scss')
//         .pipe(sass())
//         .pipe(gulp.dest("wwwroot/css/"));
//     cb();
// });
var compass = require('gulp-compass');
gulp.task('sass', function (cb) {
    gulp.src('wwwroot/css/*.scss')
        .pipe(compass({
            config_file: './config.rb',
            css: 'wwwroot/css',
            sass: 'wwwroot/css'
        }))
        .pipe(gulp.dest("wwwroot/css/"));
    cb();
});

gulp.task('default', gulp.series('sass', function (cb) {
    gulp.watch('wwwroot/css/*.scss', gulp.series('sass'));
    cb();
}));