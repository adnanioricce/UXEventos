FROM mcr.microsoft.com/mssql/server:2022-latest

ENV MSSQL_SA_PASSWORD=YourStrong!Passw0rd
ENV ACCEPT_EULA=Y

# RUN mkdir -p /usr/src/app
# COPY init-db.sh /usr/src/app/

# RUN chmod +x /usr/src/app/init-db.sql

WORKDIR /usr/src/app

COPY init.sql .

CMD /opt/mssql/bin/sqlservr & \
    sleep 30s && \
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -d master -i /usr/src/app/init.sql && \
    tail -f /dev/null

