setupProxy () {

    # remove existing certificates
    echo -e "${YELLOW} Removing existings certificates... ${RESTORE}"
    sudo security delete-certificate -c $certificatePrefix /Library/Keychains/System.keychain

    # generate key
    openssl \
        genrsa \
        -out certs/$certificatePrefix.key \
        4096

    # generate csr request
    openssl \
        req \
        -new \
        -sha256 \
        -out certs/$certificatePrefix.csr \
        -key certs/$certificatePrefix.key \
        -config openssl-san.conf

    #generate certificate from csr request
    openssl \
        x509 \
        -req \
        -days 3650 \
        -in certs/$certificatePrefix.csr \
        -signkey certs/$certificatePrefix.key \
        -out certs/$certificatePrefix.crt \
        -extensions req_ext \
        -extfile openssl-san.conf

    # generate pem
    cat certs/$certificatePrefix.crt certs/$certificatePrefix.key > certs/$certificatePrefix.pem
   
    # Write Hosts
    addHost "blogapi.ethanbarrett.com"

}
