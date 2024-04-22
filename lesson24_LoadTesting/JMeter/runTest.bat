REM add path to apache:
set jMeterPath="..."
java -jar %jMeterPath%\bin\ApacheJMeter.jar -n -t Loginalot_CLI.jmx -l results.csv
