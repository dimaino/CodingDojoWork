SELECT * FROM friendships;
SELECT * FROM users;
INSERT INTO users (first_name, last_name, created_at, updated_at) 
VALUES ("SomeFriend", "YESAFRIEND", NOW(), NOW());

INSERT INTO friendships (user_id, friend_id, created_at, updated_at) 
VALUES (4, 1, NOW(), NOW());

SELECT users.first_name, users.last_name, users2.first_name as friend_first_name, users2.last_name as friends_last_name FROM users
LEFT JOIN friendships
ON users.id = friendships.user_id
LEFT JOIN users as users2
ON users2.id = friendships.friend_id;
