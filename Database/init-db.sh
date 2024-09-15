#!/bin/bash
sleep 30s

/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $MSSQL_SA_PASSWORD -d sucessodb -i /usr/src/sqlscripts/init.sql
