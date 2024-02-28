USE [TaskTaker];

-- Inserting data into Status table
INSERT INTO [Status] ([Progress])
VALUES
('Not Started'),
('Planned'),
('Begun'),
('Stuck'),
('Complete');

-- Inserting data into UserProfile table
INSERT INTO [UserProfile] ([DisplayName], [FirstName], [LastName], [Email], [CreateDateTime], [ImageLocation])
VALUES
('LazyLenny', 'Lenny', 'McSlacker', 'lazylenny@example.com', '2024-02-21T10:00:00', 'https://api.macmillanenglish.com/imgproxy/rt:auto/w:227/h:305/g:no/el:1/f:webp/q:80/aHR0cHM6Ly9hcGkubWFjbWlsbGFuZW5nbGlzaC5jb20vZmlsZWFkbWluL19wcm9jZXNzZWRfL2UvMy9jc21fWW91bmdfRXhwbG9yZXJzXzFfX0xhenlfTGVubnlfMGM1OWZhZGI3Ny5qcGc'),
('OrganizedOscar', 'Oscar', 'Tidysmith', 'oscartidysmith@example.com', '2024-02-21T11:00:00', 'https://www.rd.com/wp-content/uploads/2018/02/GettyImages-524332596-e1580137462783.jpg?fit=335,335'),
('EnergeticEva', 'Eva', 'Buzz', 'energeticeva@example.com', '2024-02-21T12:00:00', 'https://static.wikia.nocookie.net/little-monsters-cbbc-on-choice/images/b/ba/Energetic_Eva.png/revision/latest?cb=20190502222122'),
('StuckSam', 'Sam', 'Sticky', 'stucksam@example.com', '2024-02-21T13:00:00', 'https://i0.wp.com/doctorsam7.blog/wp-content/uploads/2019/12/STUCK-SANTA.jpg?resize=624%2C720&ssl=1'),
('CompleteCarl', 'Carl', 'Finito', 'completecarl@example.com', '2024-02-21T14:00:00', 'https://images-cdn.9gag.com/photo/an9829L_700b.jpg');

-- Inserting data into Subscription table
INSERT INTO [Subscription] ([SubscriberUserProfileId], [ProviderUserProfileId])
VALUES
(1, 2),
(2, 1),
(3, 4),
(4, 5),
(5, 3);

-- Inserting data into TaskList table
INSERT INTO [TaskList] ([UserId], [ListTitle])
VALUES
(1, 'Procrastination Party'),
(2, 'To-Do Triumphs'),
(3, 'Energy Exploits'),
(4, 'Sticky Situations'),
(5, 'Completion Celebrations');

-- Inserting data into Task table
INSERT INTO [Task] ([TaskListId], [Title], [Description], [StatusId], [EstimatedTime], [ActualTime], [Completed])
VALUES
(1, 'Avoid Doing Anything', 'Find the most creative ways to procrastinate', 1, 240, NULL, 0),
(2, 'Plan the Perfect Plan', 'Map out every minute detail of your tasks', 2, 120, NULL, 0),
(3, 'Channel Your Inner Energizer Bunny', 'Take on tasks with boundless enthusiasm', 3, 180, NULL, 0),
(4, 'Escape the Sticky Situation', 'Figure out how to get unstuck from sticky situations', 4, 60, NULL, 0),
(5, 'Celebrate Completion', 'Bask in the glory of completing tasks', 5, 30, NULL, 0),
(1, 'Watch Funny Cat Videos', 'Spend an hour watching hilarious cat videos on the internet', 1, 60, NULL, 0),
(1, 'Take a Power Nap', 'Catch some Zs for a quick energy boost', 1, 30, NULL, 0),
(1, 'Pretend [to] be Busy', 'Move papers around your desk and type vigorously on your keyboard', 1, 45, NULL, 0),
(2, '[Create] Color-Coded Schedule', 'Organize tasks into color-coded categories for better visualization', 2, 90, NULL, 0),
(2, '[Set] Reminders for Everything', 'Set reminders on your phone for every minute detail of your day', 2, 60, NULL, 0),
(2, 'Make [To]-Do Lists for To-Do Lists', 'Because organizing your tasks is the first task!', 2, 120, NULL, 0),
(3, 'Jumping Jack Marathon', 'See how many jumping jacks you can do in 10 [minutes]', 3, 10, NULL, 0),
(3, 'Dance Party [Break]', 'Take a break and dance like nobodys watching', 3, 15, NULL, 0),
(3, 'Brainstorm Crazy Ideas', 'Let your imagination run wild and jot down your craziest ideas', 3, 30, NULL, 0),
(4, 'Call IT Support', 'Get stuck on purpose and call IT support for help', 4, 20, NULL, 0),
(4, 'Google Solutions', 'Spent hours Googling for solutions to unrelated problems', 4, 180, NULL, 0),
(4, 'Take a Deep Breath', 'Take a moment to breathe deeply and calm down', 4, 5, NULL, 0),
(5, 'Throw a Completion Party', 'Celebrate completing tasks with confetti and balloons', 5, 60, NULL, 0),
(5, 'Reward Yourself with Ice Cream', 'Indulge in your favorite flavor of ice cream as a reward', 5, 15, NULL, 0),
(5, 'Plan the Next Adventure', 'Start planning your next exciting project or adventure', 5, 45, NULL, 0);


-- Inserting data into Comment table
INSERT INTO [Comment] ([TaskId], [UserId], [Content], [Timestamp])
VALUES
(1, 1, 'Procrastination level: expert!', '2024-02-21T15:00:00'),
(2, 2, 'Planning is the key to success!', '2024-02-21T16:00:00'),
(3, 3, 'Energize and conquer!', '2024-02-21T17:00:00'),
(4, 4, 'Stuck like glue!', '2024-02-21T18:00:00'),
(5, 5, 'Mission accomplished!', '2024-02-21T19:00:00'),
(1, 1, 'Best task ever!', '2024-02-22T10:00:00'),
(1, 2, 'Don''t forget to watch the "fail" compilations!', '2024-02-22T11:00:00'),
(2, 3, 'Power naps are life savers!', '2024-02-22T12:00:00'),
(2, 4, 'Make sure to set an alarm!', '2024-02-22T13:00:00'),
(3, 5, 'Look busy, do nothing!', '2024-02-22T14:00:00'),
(3, 1, 'Pretend to shuffle papers like a pro!', '2024-02-22T15:00:00'),
(4, 2, 'Color-coded schedules make everything better!', '2024-02-22T16:00:00'),
(4, 3, 'Don''t forget to color-coordinate your pens!', '2024-02-22T17:00:00'),
(5, 4, 'Reminders for reminders!', '2024-02-22T18:00:00'),
(5, 5, 'Check your phone every minute for updates!', '2024-02-22T19:00:00'),
(6, 1, 'Organize your to-do lists alphabetically!', '2024-02-22T20:00:00'),
(6, 2, 'And then alphabetize your alphabetized lists!', '2024-02-22T21:00:00'),
(7, 3, 'Jumping jacks are the ultimate energy booster!', '2024-02-22T22:00:00'),
(7, 4, 'Keep count and aim for a new record!', '2024-02-22T23:00:00'),
(8, 5, 'Dance like nobody''s watching, even if they are!', '2024-02-23T00:00:00'),
(8, 1, 'Time to break out the disco moves!', '2024-02-23T01:00:00'),
(9, 2, 'Let your imagination run wild!', '2024-02-23T02:00:00'),
(9, 3, 'Think outside the box, way outside!', '2024-02-23T03:00:00'),
(10, 4, 'Stuck again? Time to call in the experts!', '2024-02-23T04:00:00'),
(10, 5, 'Maybe IT will bring snacks...', '2024-02-23T05:00:00'),
(11, 1, 'Google is your friend, and your procrastination partner!', '2024-02-23T06:00:00'),
(11, 2, 'Don''t get lost in the rabbit hole!', '2024-02-23T07:00:00'),
(12, 3, 'Breathe in, breathe out, and breathe in again...', '2024-02-23T08:00:00'),
(12, 4, 'Stuck or enlightened? Maybe both...', '2024-02-23T09:00:00'),
(13, 5, 'Completion party checklist: balloons, confetti, and more ice cream!', '2024-02-23T10:00:00'),
(13, 1, 'Don''t forget the party hats!', '2024-02-23T11:00:00'),
(14, 2, 'Ice cream solves everything!', '2024-02-23T12:00:00'),
(14, 3, 'The bigger the scoop, the better the reward!', '2024-02-23T13:00:00'),
(15, 4, 'Adventure awaits!', '2024-02-23T14:00:00'),
(15, 5, 'Don''t forget to pack your completion certificate!', '2024-02-23T15:00:00');
