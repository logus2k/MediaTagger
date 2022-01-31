FROM alpine:latest

RUN apk add bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib
RUN apk add libgdiplus --repository https://dl-3.alpinelinux.org/alpine/edge/testing/

WORKDIR /
COPY dotnet-sdk-6.0.101-linux-musl-x64.tar.gz dotnet.tar.gz

RUN mkdir -p /usr/share/dotnet \
    && tar -C /usr/share/dotnet -oxzf dotnet.tar.gz ./packs ./sdk ./sdk-manifests ./templates ./LICENSE.txt ./ThirdPartyNotices.txt \
    && rm dotnet.tar.gz

RUN mkdir -p /usr/share/dotnet && tar zxf dotnet.tar.gz -C /usr/share/dotnet

ENV ENV="/etc/profile"

RUN export PATH=$PATH:/usr/share/dotnet
