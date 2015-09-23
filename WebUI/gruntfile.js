/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        concat: {
            options: {
                separator: ';',
                sourceMap: true
            },
            core: {
                src: [
                    'app/app.module.js',
                    'app/**/ui.*.js'
                ],
                dest: 'app/dist/ui.js'
            }
        },
        uglify: {
            core: {
                options: {
                    mangle: false,
                    sourceMap: true,
                    sourceMapIncludeSources: true,
                    sourceMapIn: 'app/dist/ui.js.map'
                },
                files: {
                    'app/dist/ui.min.js': 'app/dist/ui.js'
                }
            }
        },
        watch: {
            options: {
                spawn: false,
                debounceDelay: 3000
            },
            app: {
                files: ['app/**/*.js', '**/*.html', '!app/dist/**'],
                tasks: ['local']
            },
            configFiles: {
                files: ['app/Gruntfile.js'],
                options: {
                    reload: true
                }
            }
        },
        clean: ['app/dist'],
    });

    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-clean');

    grunt.registerTask('default', ['local', 'watch']);
    grunt.registerTask('local', ['clean', 'concat:core', 'uglify']);
};