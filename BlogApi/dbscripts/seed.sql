\connect blogdb

CREATE TABLE blog
(
 id serial PRIMARY KEY,
 title VARCHAR (50) NOT NULL,
 body VARCHAR (100) NOT NULL,
 timestamp TIMESTAMP NOT NULL
);

ALTER TABLE blog OWNER TO bloguser;

Insert into blog(title,body,timestamp) values( 'Title 1','Body 1', '1999-01-08 04:05:06');
Insert into blog(title,body,timestamp) values( 'Title 2','Body 2', '2000-01-08 04:05:06');
Insert into blog(title,body,timestamp) values( 'Title 3','Body 3', '2001-01-08 04:05:06');
Insert into blog(title,body,timestamp) values( 'Title 4','Body 4', '2002-01-08 04:05:06');