using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooksData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$7SS1oUFKdNiCbRznzPWjB./V7nZMi7TdQlyM4DI5oJPEXQ2/GnFJW");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$PF/mdyY8GNXr59t3/llzCuFvOevStHW3vNt5l73MbCEQer0NT4CY6");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$gqjVZISoG/kCZWk43v/tF.BKCm8nVNjphDP0Hl2Yb6t0.CiNWHK2G");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$f2s5Q.iUKMP.EVj2Y5NRfOwzuRtrQTBbBWUWcWMq7.vOgHpV5puBC");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$0nZMDIIdt0zKXihQAsyY8.eP7UKNlHlc23pTd/Ri9gdl40g8ycZKO");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$WnhHBRMlLdeMsOz5qbFxo.ZTX9BjSJZ9MUHmx/4ko458QfSp2uwr6");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 7,
                column: "password",
                value: "$2a$11$R4PlhUgjEyoDMMVLQW4JdOgQgiOub.Hxgpsd7a5He5r.AY5nHEPu.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 8,
                column: "password",
                value: "$2a$11$JeAzI5ngeGTXAiMO0Qc7TuFRWpyf12yWyyIwCbVwDQ1BroMskzYqS");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 9,
                column: "password",
                value: "$2a$11$DSeqlu8I6TOL7ebeMTOIh.XYu.ZXXnaOhloxZTxnI3.yosqRH/tTy");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 10,
                column: "password",
                value: "$2a$11$9rl/SM7ooc2AYR4.ONA94.sRU2nZFLvDgFRjZo1HUv37a87clqTri");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 11,
                column: "password",
                value: "$2a$11$f9j/d0MZMU1MJkjOaNxhPudV00j9bNXEUMF6R8MB7UlAXnP4rB9rO");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "book_id", "AddedDate", "author", "description", "image_link", "price", "publisher", "quantity_left", "status", "title" },
                values: new object[,]
                {
                    { 3, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trevor Noah", "Our ability to pay attention is collapsing. From the New York Times bestselling author of Chasing the Scream and Lost Connections comes a groundbreaking examination of why this is happening--and how to get our attention back.\n'The book the world needs in order to win the war on distraction.'--Adam Grant, author of Think Again\n'Read this book to save your mind.'--Susan Cain, author of Quiet\nIn the United States, teenagers can focus on one task for only sixty-five seconds at a time, and office workers average only three minutes. Like so many of us, Johann Hari was finding that constantly switching from device to device and tab to tab was a diminishing and depressing way to live. He tried all sorts of self-help solutions--even abandoning his phone for three months--but nothing seemed to work.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1626718328l/57933306.jpg", 15.65, "Houghton Mifflin Harcourt", 120, (short)1, "Born a Crime: Stories From a South African Childhood" },
                    { 6, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danielle Friedman", "A captivating blend of reportage and personal narrative that explores the untold history of women's exercise culture--from jogging and Jazzercise to Jane Fonda--and how women have parlayed physical strength into other forms of power.\nFor American women today, working out is as accepted as it is expected, fueling a multibillion-dollar fitness industrial complex. But it wasn't always this way. Seven decades ago, sweating was 'unladylike' and girls grew up believing that physical exertion would cause their uterus to 'fall out.' Most hid their muscle under sleeves and skirts. It was only in the Sixties that, thanks to a few forward-thinking fitness pioneers, women began to move en masse. When they did, journalist Danielle Friedman argues, they were participating in something subversive: the pursuit of physical strength and personal autonomy. ", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1618280362l/57699965.jpg", 7.8499999999999996, "Macmillan", 120, (short)1, "Let's Get Physical: How Women Discovered Exercise and Reshaped the World" },
                    { 7, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexa Tsoulis-Reay", "Alexa Tsoulis-Reay's Finding Normal is an author's up close tour of people who are using the Internet to challenge the boundaries of what's taboo and what it means to be normal.\nBased on a popular series of candid interviews conducted for New York magazine’s human science column—'What It's Like'—Finding Normal explores the ways that real people are using the Internet to find community, forge connections, and create identity in ways that challenge a variety of accepted sexual norms. Ranging from the atypical to the shocking, each story in Finding Normal intimately immerses the reader in the world of a person who is grappling with a unique set of circumstances relating to sexuality.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1635841774l/56269140.jpg", 13.220000000000001, "Simon & Schuster", 30, (short)1, "Finding Normal: Sex, Love, and Taboo in Our Hyperconnected World" },
                    { 8, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrisse Khan-Cullors", "In An Abolitionist's Handbook, Cullors charts a framework for how everyday activists can effectively fight for an abolitionist present and future. Filled with relatable pedagogy on the history of abolition, a reimagining of what reparations look like for Black lives and real-life anecdotes from Cullors.\nAn Abolitionist's Handbook offers a bold, innovative, and humanistic approach to how to be a modern-day abolitionist. Cullors asks us to lead with love, fierce compassion, and precision.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1625599910l/56269142.jpg", 5.7699999999999996, "Sterling", 40, (short)1, "Finding Normal: Sex, Love, and Taboo in Our Hyperconnected World" },
                    { 9, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kimberly Jones", "A breakdown of the economic and social injustices facing Black people and other marginalized citizens inspired by political activist Kimberly Jones' viral video, “How Can We Win.”\n“So if I played four hundred rounds of Monopoly with you and I had to play and give you every dime that I made, and then for fifty years, every time that I played, if you didn't like what I did, you got to burn it like they did in Tulsa and like they did in Rosewood, how can you win? How can you win?'\nWhen Kimberly Jones declared these words amid the protests spurred by the murder of George Floyd, she gave a history lesson that in just over six minutes captured the economic struggles of Black people in America.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1608042844l/55077632.jpg", 47.130000000000003, "Scholastic", 50, (short)1, "How We Can Win: Race, History and Changing the Money Game That's Rigged" },
                    { 10, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kindra Hall", "Most of the “self-stories” you tell yourself—the kind of person you say you are and the things you are capable of—are invisible to you because they have become such a part of your everyday mental routine that you don’t even recognize they exist.\nYet, these self-stories influence everything you do, everything you say, and everything you are.\nChoose Your Story, Change Your Life will help you take complete control of your self-stories and create the life you’ve always dreamed you’d have. Kindra Hall offers up a new window into your psychology, one that travels the distance from the frontiers of neuroscience to the deep inner workings of your thoughts and feelings. This eye-opening, but applicable journey will transform you from a passive listener of these limiting, unconscious thoughts to the definitive author of who you are and everything you want to be.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1635963122l/57468177._SY475_.jpg", 24.530000000000001, "Simon & Schuster", 60, (short)1, "Choose Your Story, Change Your Life" },
                    { 11, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nadia Davis", "In this deeply personal memoir, Nadia Davis addresses her three sons with brutal honesty, hope, and strength, revealing both her childhood and adult traumas that led to issues with addiction and dysfunctional relationships, as well as to discuss transformational healing, spirituality, intensive trauma therapy, chronic pain management, healthy co-parenting and intimacy, preventing learned toxic masculinity, and more.\nAs a young high-profile lawyer, school board member in Southern California, county supervisor in the Bay Area, recipient of state and national public service awards, and former wife of California's attorney general and treasurer, Nadia Davis has been a public figure in California for over two decades. Her experience with addiction in the trenches of a highly publicized abusive relationship led Davis through the challenges of public shaming, injustice, arrests, mandated treatment, and a total lack of privacy for personal issues.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1639278749l/59804755._SY475_.jpg", 14.960000000000001, "Sterling", 70, (short)1, "Home Is Within You: A Memoir" },
                    { 12, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walter Isaacson", "When Jennifer Doudna was in sixth grade, she came home one day to find that her dad had left a paperback titled The Double Helix on her bed. As she sped through the pages, she became enthralled by the intense drama behind the competition to discover the code of life. Even though her high school counselor told her girls didn’t become scientists, she decided she would.\nDriven by a passion to understand how nature works and to turn discoveries into inventions, she would help to make what the book’s author, James Watson, told her was the most important biological advance since his co-discovery of the structure of DNA. She and her collaborators turned ​a curiosity ​of nature into an invention that will transform the human race: an easy-to-use tool that can edit DNA. Known as CRISPR, it opened a brave new world of medical miracles and moral questions. ", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1610894755l/54968118.jpg", 2.7599999999999998, "HarperCollins", 80, (short)1, "The Code Breaker: Jennifer Doudna, Gene Editing, and the Future of the Human Race" },
                    { 13, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laurie Zaleski", "An inspiring and moving memoir of the author's turbulent life with 600 rescue animals.\nLaurie Zaleski never aspired to run an animal rescue; that was her mother Annie's dream. But from girlhood, Laurie was determined to make the dream come true. Thirty years later as a successful businesswoman, she did it, buying a 15-acre farm deep in the Pinelands of South Jersey. She was planning to relocate Annie and her caravan of ragtag rescues--horses and goats, dogs and cats, chickens and pigs--when Annie died, just two weeks before moving day. In her heartbreak, Laurie resolved to make her mother's dream her own. In 2001, she established the Funny Farm Animal Rescue outside Mays Landing, New Jersey. Today, she carries on Annie's mission to save abused and neglected animals.\nFunny Farm is Laurie's story: of promises kept, dreams fulfilled, and animals lost and found. It's the story of Annie McNulty, who fled a nightmarish marriage with few skills, no money and no resources, dragging three kids behind her, and accumulating hundreds of cast-off animals on the way. And lastly, it's the story of the brave, incredible, and adorable animals that were rescued.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1623669464l/56269214.jpg", 25.879999999999999, "Disney Publishing Worldwide", 411, (short)1, "Funny Farm: My Unexpected Life with 600 Rescue Animals" },
                    { 14, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sheila Heti", "Pure Colour is a galaxy of a novel: explosive, celestially bright, huge, and streaked with beauty. It is a contemporary bible, an atlas of feeling, and an absurdly funny guide to the great (and terrible) things about being alive. Sheila Heti is a philosopher of modern experience, and she has reimagined what a book can hold.\nHere we are, just living in the first draft of Creation, which was made by some great artist, who is now getting ready to tear it apart.\nIn this first draft of the world, a woman named Mira leaves home to study. There, she meets Annie, whose tremendous power opens Mira’s chest like a portal—to what, she doesn’t know. When Mira is older, her beloved father dies, and his spirit passes into her. Together, they become a leaf on a tree. But photosynthesis gets boring, and being alive is a problem that cannot be solved, even by a leaf. Eventually, Mira must remember the human world she’s left behind, including Annie, and choose whether or not to return. ", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1629822011l/57693639.jpg", 5.54, "Workman", 197, (short)1, "Pure Colour" },
                    { 15, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kai Harris", "In the vein of Jesmyn Ward's Salvage the Bones and Sue Monk Kidd's The Secret Life of Bees, a coming-of-age novel told from the perspective of eleven-year-old KB, as she and her sister try, over the course of a summer, to make sense of their new life with their estranged grandfather after the death of their father and disappearance of their mother\nAfter her father dies of an overdose and the debts incurred from his addiction cause the loss of the family home in Detroit, almost-eleven-year-old Kenyatta Bernice (KB) and her teenage sister, Nia, are sent by their overwhelmed mother to live with their estranged grandfather in Lansing.\nOver the course of a single, sweltering summer, KB attempts to get her bearings in a world that has turned upside down--a father who is labeled a fiend; a mother whose smile no longer reaches her eyes; a sister, once her best friend, who has crossed the threshold of adolescence and suddenly wants nothing to do with her; a grandfather who is grumpy and silent; the white kids across the street who are friendly, but only sometimes. And all of them are keeping secrets.\nPinballing between resentment, abandonment, and loneliness, KB is forced to carve out a different identity for herself and find her own voice. As she examines the jagged pieces of her recently shattered world, she learns that while some truths cut deep, a new life--and a new KB--can be built from the shards.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1630947521l/55591342.jpg", 6.1100000000000003, "Penguin Random House", 126, (short)1, "What the Fireflies Knew" },
                    { 16, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charmaine Wilkerson", "In this moving debut novel, two estranged siblings must set aside their differences to deal with their mother's death and her hidden past--a journey of discovery that takes them from the Caribbean to London to California and ends with her famous black cake.\nWe can't choose what we inherit. But can we choose who we become?\nIn present-day California, Eleanor Bennett's death leaves behind a puzzling inheritance for her two children, Byron and Benny: a traditional Caribbean black cake, made from a family recipe with a long history, and a voice recording. In her message, Eleanor shares a tumultuous story about a headstrong young swimmer who escapes her island home under suspicion of murder. The heartbreaking tale Eleanor unfolds, the secrets she still holds back, and the mystery of a long-lost child, challenge everything the siblings thought they knew about their lineage, and themselves.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1623664615l/57926137.jpg", 31.879999999999999, "Workman", 100, (short)1, "Black Cake" },
                    { 17, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julie Otsuka", "From the award winning author of The Buddha in the Attic and When the Emperor Was Divine, a tour de force of economy, precision, and emotional power about what happens to a group of obsessed recreational swimmers when a crack appears at the bottom of their local pool.\nThe swimmers are unknown to each other except through their private routines (slow lane, fast lane), and the solace each takes in their morning or afternoon laps. But when a crack appears at the bottom of the pool, they are cast out into an unforgiving world without comfort or relief.\nOne of these swimmers is Alice, who is slowly losing her memory. For Alice, the pool was a final stand against the darkness of her encroaching dementia. Without the fellowship of other swimmers and the routine of her daily laps she is plunged into dislocation and chaos, swept into memories of her childhood and the Japanese internment camp in which she spent the war. Narrated by Alice's daughter, who witnesses her stark and devastating decline, The Swimmers is a searing, intimate story of mothers and daughters, and the sorrows of implacable loss, written in spellbinding, incantatory prose.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1638151704l/58214333.jpg", 23.0, "Workman", 70, (short)1, "The Swimmers" },
                    { 18, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patti Callahan", "From Patti Callahan, the bestselling author of Becoming Mrs. Lewis, comes another enchanting story that pulls back the curtain on the early life of C. S. Lewis.\n“Where did Narnia come from?”\nThe answer will change everything.\nMegs Devonshire is brilliant with numbers and equations, on a scholarship at Oxford, and dreams of solving the greatest mysteries of physics.\nShe prefers the dependability of facts—except for one: the younger brother she loves with all her heart doesn’t have long to live. When George becomes captivated by a copy of a brand-new book called The Lion, the Witch and the Wardrobe and begs her to find out where Narnia came from, there’s no way she can refuse.\nDespite her timidity about approaching the famous author, Megs soon finds herself taking tea with the Oxford don and his own brother, imploring them for answers. What she receives instead are more stories . . . stories of Jack Lewis’s life, which she takes home to George. ", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1616161736l/57099601.jpg", 36.07, "Simon & Schuster", 97, (short)1, "Once Upon a Wardrobe" },
                    { 19, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ángel Martín Gómez", "Hace unos años me rompí por completo. Tanto como para que tuvieran que atarme a la cama de un hospital psiquiátrico para evitar que pudiera hacerme daño.\nNo tengo ni idea de cuándo empezó a formarse mi locura.\nA lo mejor nací genéticamente predispuesto.\nA lo mejor fui macerando una depresión callándome ciertas cosas por no preocupar a los demás.\nO a lo mejor simplemente hay cerebros que de la noche a la mañana hacen crec y se acabó.\nSi algo he descubierto en todo este tiempo es que cuando cuentas abiertamente que se te ha pirado la cabeza, la gente enseguida le pone el sello de tabú.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1631184339l/58956328._SY475_.jpg", 28.5, "Macmillan", 10, (short)1, "Por si las voces vuelven" },
                    { 20, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob Woodward", "The book covers the end of the Trump presidency and the early months of the Biden presidency.\nThe transition from President Donald J. Trump to President Joseph R. Biden Jr. stands as one of the most dangerous periods in American history.\nBut as # 1 internationally bestselling author Bob Woodward and acclaimed reporter Robert Costa reveal for the first time, it was far more than just a domestic political crisis.\nWoodward and Costa interviewed more than 200 people at the center of the turmoil, resulting in more than 6,000 pages of transcripts—and a spellbinding and definitive portrait of a nation on the brink. ", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1629245743l/58546518.jpg", 14.699999999999999, "Disney Publishing Worldwide", 1, (short)1, "Peril" },
                    { 21, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rosemary Sullivan", "Message on the website of the Dutch publisher:\nIn the book entitled The Betrayal of Anne Frank, the impression is created that the Jewish notary Arnold van den Bergh is the betrayer of Anne Frank, her family and the other people in hiding in the Secret Annex. Based on expert reactions, we have come to the conclusion that the investigation team's conclusion that the betrayer was most probably Arnold van den Bergh is not adequately supported by the available factual material. We apologise to anyone who feels offended by this book. This applies in particular to the surviving relatives and other family members of Arnold van den Bergh.\nAmbo|Anthos publishers\nUsing new technology, recently discovered documents and sophisticated investigative techniques, an international team—led by an obsessed former FBI agent—has finally solved the mystery that has haunted generations since World War II: Who betrayed Anne Frank and her family? And why? ", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1637793352l/54496090.jpg", 45.280000000000001, "Workman", 57, (short)2, "The Betrayal of Anne Frank: A Cold Case Investigation" },
                    { 22, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Schur", "From the creator of The Good Place and the cocreator of Parks and Recreation, a hilarious, thought-provoking guide to living an ethical life, drawing on 2,500 years of deep thinking from around the world.\nMost people think of themselves as “good,” but it’s not always easy to determine what’s “good” or “bad”—especially in a world filled with complicated choices and pitfalls and booby traps and bad advice. Fortunately, many smart philosophers have been pondering this conundrum for millennia and they have guidance for us. With bright wit and deep insight, How to Be Perfect explains concepts like deontology, utilitarianism, existentialism, ubuntu, and more so we can sound cool at parties and become better people. ", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1642042986l/58484901.jpg", 46.0, "Disney Publishing Worldwide", 287, (short)1, "How to Be Perfect: The Correct Answer to Every Moral Question" },
                    { 23, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elle Cosimano", "Finlay Donovan is killing it...except, she’s really not. A stressed-out single mom of two and struggling novelist, Finlay’s life is in chaos: The new book she promised her literary agent isn’t written; her ex-husband fired the nanny without telling her; and this morning she had to send her four-year-old to school with hair duct-taped to her head after an incident with scissors.\nWhen Finlay is overheard discussing the plot of her new suspense novel with her agent over lunch, she’s mistaken for a contract killer and inadvertently accepts an offer to dispose of a problem husband in order to make ends meet. She soon discovers that crime in real life is a lot more difficult than its fictional counterpart, as she becomes tangled in a real-life murder investigation.\nFast-paced, deliciously witty, and wholeheartedly authentic in depicting the frustrations and triumphs of motherhood in all its messiness, hilarity, and heartfelt moments, Finlay Donovan Is Killing It is the first in a brilliant new series from award-winning Elle Cosimano.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1604995905l/53138099.jpg", 10.98, "Houghton Mifflin Harcourt", 342, (short)1, "Finlay Donovan Is Killing It" },
                    { 24, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claire Douglas", "It was the house of their dreams. Until the bodies were found . . .\nBODIES FOUND UNDER PATIO\nWhen pregnant Saffron Cutler moves into 9 Skelton Place with boyfriend Tom and sets about renovations the last thing she expects is builders uncovering a body - two bodies, in fact.\nPOLICE INVESTIGATE\nForensics indicate the bodies have been buried at least thirty years. Nothing Saffy need worry herself over. Until the police launch a murder investigation and ask to speak to the cottage's former owner - her grandmother, Rose.\nOWNER QUESTIONED\nRose is in a care home and Alzheimer's means her memory is increasingly confused. She can't help the police but it is clear she remembers something.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1629042627l/58774738._SY475_.jpg", 14.140000000000001, "Hachette Book Group", 18, (short)1, "The Couple at No. 9" },
                    { 25, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruth Ware", "Getting snowed in at a beautiful, rustic mountain chalet doesn’t sound like the worst problem in the world, especially when there’s a breathtaking vista, a cozy fire, and company to keep you warm. But what happens when that company is eight of your coworkers…and you can’t trust any of them?\nWhen an off-site company retreat meant to promote mindfulness and collaboration goes utterly wrong when an avalanche hits, the corporate food chain becomes irrelevant and survival trumps togetherness. Come Monday morning, how many members short will the team be?\nThe #1 New York Times bestselling author of The Turn of the Key and In a Dark Dark Wood returns with another suspenseful thriller set on a snow-covered mountain.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1587655884l/50892433._SY475_.jpg", 27.739999999999998, "HarperCollins", 333, (short)1, "One by One" },
                    { 26, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kelley McNeil", "What if everything you’ve ever loved, ever known, ever believed to be true…just disappeared?\nAnnie Beyers has everything—a beautiful house, a loving husband, and an adorable daughter. It’s a day like any other when she takes Hannah to the pediatrician…until she wakes hours later from a car accident. When she asks for her daughter, confused doctors tell Annie that Hannah never existed. In fact, nothing after waking from the crash is the same as Annie remembers. Five happy years of her life apparently never happened.\nAnnie’s marriage is coming to an end. Now a successful artist living in Manhattan, she’s no longer home in their beloved upstate farmhouse. Her long-estranged sister is more like a best friend, and her recently deceased dog is alive and well. With each passing day, Annie’s remembered past and unfamiliar present begin to blur. Haunted by visions of Hannah, and with knowledge of things she can’t explain, Annie wonders…is everyone lying to her?", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1626938014l/57597229.jpg", 25.890000000000001, "Houghton Mifflin Harcourt", 54, (short)1, "A Day Like This" },
                    { 27, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riley Sager", "Charlie Jordan is being driven across the country by a serial killer. Maybe.\nBehind the wheel is Josh Baxter, a stranger Charlie met by the college ride share board, who also has a good reason for leaving university in the middle of term. On the road they share their stories, carefully avoiding the subject dominating the news - the Campus Killer, who's tied up and stabbed three students in the span of a year, has just struck again.\nTravelling the lengthy journey between university and their final destination, Charlie begins to notice discrepancies in Josh's story.\nAs she begins to plan her escape from the man she is becoming certain is the killer, she starts to suspect that Josh knows exactly what she's thinking. ", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1603780911l/55628983.jpg", 35.939999999999998, "Disney Publishing Worldwide", 430, (short)1, "Survive the Night" },
                    { 28, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Imani Perry", "An essential, surprising journey through the history, rituals, and landscapes of the American South—and a revelatory argument for why you must understand the South in order to understand America\nWe all think we know the South. Even those who have never lived there can rattle off a list of signifiers: the Civil War, Gone with the Wind, the Ku Klux Klan, plantations, football, Jim Crow, slavery. But the idiosyncrasies, dispositions, and habits of the region are stranger and more complex than much of the country tends to acknowledge. In South to America, Imani Perry shows that the meaning of American is inextricably linked with the South, and that our understanding of its history and culture is the key to understanding the nation as a whole.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1628531701l/55276620.jpg", 15.550000000000001, "Scholastic", 171, (short)1, "South to America: A Journey Below the Mason Dixon to Understand the Soul of a Nation" },
                    { 29, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Albanese", "Conceived against the backdrop of the global pandemic, this modern-day allegory explores the illusion of control and the pursuit of peace. Join our hero and discover that happiness is not always found in the places we expect.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1642444032l/60147335._SX318_.jpg", 23.039999999999999, "Workman", 0, (short)1, "The Boy Who Loved Boxes: A Children's Book for Adults" },
                    { 30, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kathryn Schulz", "Eighteen months before Kathryn Schulz's father died, she met the woman she would marry. In Lost & Found, she weaves the story of those relationships into a brilliant exploration of the role that loss and discovery play in all of our lives. The resulting book is part memoir, part guidebook to living in a world that is simultaneously full of wonder and joy and wretchedness and suffering--a world that always demands both our gratitude and our grief. A staff writer at The New Yorker and winner of the Pulitzer Prize, Schulz writes with curiosity, tenderness, erudition, and wit about our finite yet infinitely complicated lives. Lost & Found is an enduring account of love in all its many forms from one of the great writers of our time.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1620412715l/57800384.jpg", 17.77, "HarperCollins", 45, (short)1, "Lost & Found: A Memoir" },
                    { 31, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kendra James", "“[C]harming and surprising. . . The work of Admissions is laying down, with wit and care, the burden James assumed at 15, that she — or any Black student, or all Black students — would manage the failures of a racially illiterate community. . . The best depiction of elite whiteness I’ve read.”—New York Times\nA Most Anticipated Book by Vogue.com  ·  Parade · Town & Country · Nylon ·New York Post · Lit Hub · BookRiot · Electric Literature · Publishers Weekly · Bustle · Fodor's Travel· Business Insider · Pop Sugar · InsideHook · SheReads\nEarly on in Kendra James’ professional life, she began to feel like she was selling a lie. As an admissions officer specializing in diversity recruitment for independent prep schools, she persuaded students and families to embark on the same perilous journey she herself had made—to attend cutthroat and largely white schools similar to The Taft School, where she had been the first African-American legacy student only a few years earlier. Her new job forced her to reflect on her own elite education experience, and to realize how disillusioned she had become with America’s inequitable system.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1625496266l/57941474.jpg", 22.890000000000001, "Houghton Mifflin Harcourt", 21, (short)1, "Admissions: A Memoir of Surviving Boarding School" },
                    { 32, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura Coates", "“A firsthand, eye-opening story of a prosecutor that exposes the devastating criminal punishment system. Laura Coates bleeds for justice on the page.” —Ibram X. Kendi, National Book Award–winning author of Stamped from the Beginning and How to Be an Antiracist\nWhen Laura Coates joined the Department of Justice as a prosecutor, she wanted to advocate for the most vulnerable among us. But she quickly realized that even with the best intentions, “the pursuit of justice creates injustice.”", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1640285119l/58438599.jpg", 39.409999999999997, "Workman", 467, (short)1, "Just Pursuit: A Black Prosecutor's Fight for Fairness" },
                    { 33, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rachel Krantz", "An award-winning journalist delves into the growing trend toward relationships--including her own--that push love beyond the familiar borders of monogamy.\nWhen Rachel Krantz met and fell for Adam, he told her that he was looking for a committed partnership--just one that did not include exclusivity. Excited and a little trepidatious, Rachel set out to see whether love and a serious partnership with Adam could coexist alongside the freedom to explore relationships with other people. Their relationship was designed to strike an exquisite balance between intimacy and independence, calibrated to fan desire for the long haul. ", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1635950610l/57933307.jpg", 44.549999999999997, "Hachette Book Group", 457, (short)1, "Open: An Uncensored Memoir of Love, Liberation, and Non-Monogamy" },
                    { 34, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carl Bernstein", "'In this triumphant memoir, Carl Bernstein, the Pulitzer Prize-winning coauthor of All the President’s Men and pioneer of investigative journalism, recalls his beginnings as an audacious teenage newspaper reporter in the nation’s capital-a winning tale of scrapes, gumshoeing, and American bedlam.\nIn 1960, Bernstein was just a sixteen-year-old at considerable risk of failing to graduate high school. Inquisitive, self-taught-and, yes, truant-Bernstein landed a job as a copyboy at the Evening Star, the afternoon paper in Washington. By nineteen, he was a reporter there.\nIn Chasing History, Bernstein recalls the origins of his storied journalistic career as he chronicles the Kennedy era, the swelling civil rights movement, and a slew of grisly crimes. He spins a buoyant, frenetic account of educating himself in what Bob Woodward describes as “the genius of perpetual engagement.'", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1604997036l/55077570.jpg", 35.770000000000003, "Hachette Book Group", 323, (short)1, "Chasing History: A Kid in the Newsroom" },
                    { 35, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edgar Gomez", "This witty memoir traces a touching and often hilarious spiralic path to embracing a gay, Latinx identity against a culture of machismo—from a cockfighting ring in Nicaragua to cities across the U.S.—and the bath houses, night clubs, and drag queens who help redefine pride.\n'I’ve always found the definition of machismo to be ironic, considering that pride is a word almost unanimously associated with queer people, the enemy of machistas. In particular, effeminate queer men represent a simultaneous rejection and embrace of masculinity . . . In a world desperate to erase us, queer Latinx men must find ways to hold onto pride for survival, but excessive male pride is often what we are battling, both in ourselves and in others.'", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1617737622l/54417380.jpg", 32.719999999999999, "Sterling", 1, (short)1, "High-Risk Homosexual" },
                    { 36, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wajahat Ali", "This is just one of the many warm, lovely, and helpful tips that Wajahat Ali and other children of immigrants receive on a daily basis. Go back where, exactly? Fremont, California, where he grew up, but is now an unaffordable place to live? Or Pakistan, the country his parents left behind a half-century ago?\nGrowing up living the suburban American dream, young Wajahat devoured comic books (devoid of brown superheroes) and fielded well-intentioned advice from uncles and aunties. (“Become a doctor!”) He had turmeric stains under his fingernails, was accident-prone, suffered from OCD, and wore Husky pants, but he was as American as his neighbors, with roots all over the world. Then, while Ali was studying at University of California, Berkeley, 9/11 happened. Muslims replaced communists as America’s enemy #1, and he became an accidental spokesman and ambassador of all ordinary, unthreatening things Muslim-y. ", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1636346546l/58085229.jpg", 7.9400000000000004, "Houghton Mifflin Harcourt", 4, (short)1, "Go Back to Where You Came From: And Other Helpful Recommendations on How to Become American" },
                    { 37, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colette Brooks", "For readers of Rebecca Solnit and Jenny Odell, this poetic and inventive blend of history, memoir, and visual essay reflects on how we can resist the erasure of our collective memory in this American century.\nOur sense of our history requires us to recall the details of time, of experiences that help us find our place in the world together and encourage us in the search for our individual identities. When we lose sight of the past, our ability to see ourselves and to understand one another is diminished.\nIn this book, Colette Brooks explores how some of the more forgotten aspects of recent American experiences explain our challenging and often puzzling present. Through intimate and meticulously researched retellings of individual stories of violence, misfortune, chaos, and persistence—from the first mass shooting in America from the tower at the University of Texas, the televised assassinations of John F. Kennedy and Lee Harvey Oswald, life with nuclear bombs and the Doomsday Clock, obsessive diarists and round-the-clock surveillance, to pandemics and COVID-19—Brooks is able to reframe our country’s narratives with new insight to create a prismatic account of how efforts to reclaim the past can be redemptive, freeing us from the tyranny of the present moment.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1618838089l/57793233.jpg", 26.539999999999999, "Disney Publishing Worldwide", 16, (short)1, "Trapped in the Present Tense" },
                    { 38, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor Harris", "A Black mother bumps up against the limits of everything she thought she believed—about science and medicine, about motherhood, and about her faith—in search of the truth about her son.\nOne morning, Tophs, Taylor Harris’s round-cheeked, lively twenty-two-month-old, wakes up listless and unresponsive. She rushes Tophs to the doctor, ignoring the part of herself, trained by years of therapy for generalized anxiety disorder, that tries to whisper that she’s overreacting. But at the hospital, her maternal instincts are confirmed: something is wrong with her boy, and Taylor’s life will never be the same.\nWith every question the doctors answer about Tophs’s increasingly troubling symptoms, more arise, and Taylor dives into the search for a diagnosis. She spends countless hours trying to navigate health and education systems that can be hostile to Black mothers and children; at night she googles, prays, and interrogates her every action. Some days, her sweet, charismatic boy seems just fine—others, he struggles to answer simple questions. What is she missing? ", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1618837844l/57793212._SY475_.jpg", 43.520000000000003, "Hachette Book Group", 190, (short)1, "This Boy We Made: A Memoir of Motherhood, Genetics, and Facing the Unknown" },
                    { 39, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charles J. Shields", "The moving story of the life of the woman behind A Raisin in the Sun, the most widely anthologized, read, and performed play of the American stage, by the New York Times bestselling author of Mockingbird: A Portrait of Harper Lee\nWritten when she was just twenty-eight, Lorraine Hansberry’s landmark A Raisin in the Sun is listed by the National Theatre as one of the hundred most significant works of the twentieth century. Hansberry was the first Black woman to have a play performed on Broadway, and the first Black and youngest American playwright to win a New York Critics’ Circle Award.\nCharles J. Shields’s authoritative biography of one of the twentieth century’s most admired playwrights examines the parts of Lorraine Hansberry’s life that have escaped public knowledge: the influence of her upper-class background, her fight for peace and nuclear disarmament, the reason why she embraced Communism during the Cold War, and her dependence on her white husband—her best friend, critic, and promoter. Many of the identity issues about class, sexuality, and race that she struggled with are relevant and urgent today.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1628534767l/49672267.jpg", 40.590000000000003, "Penguin Random House", 70, (short)1, "Lorraine Hansberry: The Life Behind A Raisin in the Sun" },
                    { 40, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michelle Obama", "In a life filled with meaning and accomplishment, Michelle Obama has emerged as one of the most iconic and compelling women of our era. As First Lady of the United States of America—the first African American to serve in that role—she helped create the most welcoming and inclusive White House in history, while also establishing herself as a powerful advocate for women and girls in the U.S. and around the world, dramatically changing the ways that families pursue healthier and more active lives, and standing with her husband as he led America through some of its most harrowing moments. Along the way, she showed us a few dance moves, crushed Carpool Karaoke, and raised two down-to-earth daughters under an unforgiving media glare.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1528206996l/38746485.jpg", 35.200000000000003, "Penguin Random House", 50, (short)1, "Becoming" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 40);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$LuVXu4z2izB5AGbr8PkCUO3urg1DyrFuW1MEcRCgCfvRlU9Uqot5W");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$cOVsoiD.QtWsZ4cPYNscGO0woRwOBykpH1ORnAhWMy3Dz2nF.zfjy");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$bdLf3gdK3qUUO0jYOb1yYeRdON1jmmXIaTbtVqTYXC9BrqdhCaWz2");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$IAqsvenleUcp3PfZGTA2huQFOZs5C1dAmUCWr8W88q8NLYtz9CXc.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$L.UelH77wJ4vgi6Gy.En8OH9pRgceJ3AVd2sVcrz.O6fbqEyW2QKG");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$vB/hmdxsolBpaEWHbyp/7.cYbJLsKKCIMi5I/eOOkcC4Zpck2tXR2");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 7,
                column: "password",
                value: "$2a$11$83KXaIAc.N0QwUV1V/J69OTJ4Ba034AiRpSPAY9g6eVP.KNItR8Su");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 8,
                column: "password",
                value: "$2a$11$knBb94.ORyoZ0vhW8WOwp.vwX6CZCbYCGWNWX.fh2M0e.PhW.2u.y");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 9,
                column: "password",
                value: "$2a$11$sFJq7C.SyeAIRrVgELQYs.jeM0QG2EpTm5OhC3yeohXVTylFfUVwm");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 10,
                column: "password",
                value: "$2a$11$2N22iTOMNIbhfMhMq4LjC.U2jmjgNQ0jIBL6OBEuWWyyXt5H7Ou6W");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 11,
                column: "password",
                value: "$2a$11$o2xq8Cd2w.nxkBX0ePuHleZojaByUGH.P7AUmlrHvEK7KOxHgiBKO");
        }
    }
}
