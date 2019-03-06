import java.io.*;

public class WordDictionary {
    public static void main(String [] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String [] words = {"Amazing", "Anger", "Angry", "Answer", "Ask–", "Awful", "Bad", "Beautiful", "Begin", "Big", "Brave", "Break", "Bright", "Calm", "Come", "Cool", "Crooked", "Cry", "Cut", "Dangerous", "Dark", "Decide", "Definite", "Delicious", "Describe", "Destroy", "Difference", "Do", "Dull", "Eager", "End", "Enjoy", "Explain", "Fair", "Fall", "False", "Famous", "Fast", "Fat", "Fear", "Fly", "Funny", "Get", "Go", "Good", "Great", "Gross", "Happy", "Hate", "Have", "Help", "Hide", "Hurry", "Hurt", "Idea", "Important", "Interesting", "Keep", "Kill", "Lazy", "Little", "Look", "Love", "Make", "Mark", "Mischievous", "Move", "Moody", "Neat", "New", "Old", "Part", "Place", "Plan", "Popular", "Predicament", "Put", "Quiet", "Right", "Run", "Say/Tell", "Scared", "Show", "Slow", "Stop", "Story", "Strange", "Take", "Tell", "Think", "Trouble", "True", "Ugly", "Unhappy", "Use", "Wrong"};
        
        String [] meanings = {
            "incredible, unbelievable, improbable, fabulous, wonderful, fantastic, astonishing, astounding, extraordinary",
            "enrage, infuriate, arouse, nettle, exasperate, inflame, madden",
            "mad, furious, enraged, excited, wrathful, indignant, exasperated, aroused, inflamed",
            "reply, respond, retort, acknowledge",
            "question, inquire, of, seek, information, from, put, a, question, to, demand, request, expect, inquire, query, interrogate, examine, quiz",
            "dreadful, terrible, abominable, bad, poor, unpleasant",
            "evil, immoral, wicked, corrupt, sinful, depraved, rotten, contaminated, spoiled, tainted, harmful, injurious, unfavorable, defective, inferior, imperfect, substandard, faulty, improper, inappropriate, unsuitable, disagreeable, unpleasant, cross, nasty, unfriendly, irascible, horrible, atrocious, outrageous, scandalous, infamous, wrong, noxious, sinister, putrid, snide, deplorable, dismal, gross, heinous, nefarious, base, obnoxious, detestable, despicable, contemptible, foul, rank, ghastly, execrable",
            "pretty, lovely, handsome, attractive, gorgeous, dazzling, splendid, magnificent, comely, fair, ravishing, graceful, elegant, fine, exquisite, aesthetic, pleasing, shapely, delicate, stunning, glorious, heavenly, resplendent, radiant, glowing, blooming, sparkling",
            "start, open, launch, initiate, commence, inaugurate, originate",
            "enormous, huge, immense, gigantic, vast, colossal, gargantuan, large, sizable, grand, great, tall, substantial, mammoth, astronomical, ample, broad, expansive, spacious, stout, tremendous, titanic, mountainous",
            "courageous, fearless, dauntless, intrepid, plucky, daring, heroic, valorous, audacious, bold, gallant, valiant, doughty, mettlesome",
            "fracture, rupture, shatter, smash, wreck, crash, demolish, atomize",
            "shining, shiny, gleaming, brilliant, sparkling, shimmering, radiant, vivid, colorful, lustrous, luminous, incandescent, intelligent, knowing, quick-witted, smart, intellectual",
            "quiet, peaceful, still, tranquil, mild, serene, smooth, composed, collected, unruffled, level-headed, unexcited, detached, aloof",
            "approach, advance, near, arrive, reach",
            "chilly, cold, frosty, wintry, icy, frigid",
            "bent, twisted, curved, hooked, zigzag",
            "shout, yell, yowl, scream, roar, bellow, weep, wail, sob, bawl",
            "gash, slash, prick, nick, sever, slice, carve, cleave, slit, chop, crop, lop, reduce",
            "perilous, hazardous, risky, uncertain, unsafe",
            "shadowy, unlit, murky, gloomy, dim, dusky, shaded, sunless, black, dismal, sad",
            "determine, settle, choose, resolve",
            "certain, sure, positive, determined, clear, distinct, obvious",
            "savory, delectable, appetizing, luscious, scrumptious, palatable, delightful, enjoyable, toothsome, exquisite",
            "portray, characterize, picture, narrate, relate, recount, represent, report, record",
            "ruin, demolish, raze, waste, kill, slay, end, extinguish",
            "disagreement, inequity, contrast, dissimilarity, incompatibility",
            "execute, enact, carry, out, finish, conclude, effect, accomplish, achieve, attain",
            "boring, tiring„, tiresome, uninteresting, slow, dumb, stupid, unimaginative, lifeless, dead, insensible, tedious, wearisome, listless, expressionless, plain, monotonous, humdrum, dreary",
            "keen, fervent, enthusiastic, involved, interested, alive, to",
            "stop, finish, terminate, conclude, close, halt, cessation, discontinuance",
            "appreciate, delight, in, be, pleased, indulge, in, luxuriate, in, bask, in, relish, devour, savor, like",
            "elaborate, clarify, define, interpret, justify, account, for",
            "just, impartial, unbiased, objective, unprejudiced, honest",
            "drop, descend, plunge, topple, tumble",
            "fake, fraudulent, counterfeit, spurious, untrue, unfounded, erroneous, deceptive, groundless, fallacious",
            "well-known, renowned, celebrated, famed, eminent, illustrious, distinguished, noted, notorious",
            "quick, rapid, speedy, fleet, hasty, snappy, mercurial, swiftly, rapidly, quickly, snappily, speedily, lickety-split, posthaste, hastily, expeditiously, like, a, flash",
            "stout, corpulent, fleshy, beefy, paunchy, plump, full, rotund, tubby, pudgy, chubby, chunky, burly, bulky, elephantine",
            "fright, dread, terror, alarm, dismay, anxiety, scare, awe, horror, panic, apprehension",
            "soar, hover, flit, wing, flee, waft, glide, coast, skim, sail, cruise",
            "humorous, amusing, droll, comic, comical, laughable, silly",
            "acquire, obtain, secure, procure, gain, fetch, find, score, accumulate, win, earn, rep, catch, net, bag, derive, collect, gather, glean, pick, up, accept, come, by, regain, salvage",
            "recede, depart, fade, disappear, move, travel, proceed",
            "excellent, fine, superior, wonderful, marvelous, qualified, suited, suitable, apt, proper, capable, generous, kindly, friendly, gracious, obliging, pleasant, agreeable, pleasurable, satisfactory, well-behaved, obedient, honorable, reliable, trustworthy, safe, favorable, profitable, advantageous, righteous, expedient, helpful, valid, genuine, ample, salubrious, estimable, beneficial, splendid, great, noble, worthy, first-rate, top-notch, grand, sterling, superb, respectable, edifying",
            "noteworthy, worthy, distinguished, remarkable, grand, considerable, powerful, much, mighty",
            "improper, rude, coarse, indecent, crude, vulgar, outrageous, extreme, grievous, shameful, uncouth, obscene, low",
            "pleased, contented, satisfied, delighted, elated, joyful, cheerful, ecstatic, jubilant, gay, tickled, gratified, glad, blissful, overjoyed",
            "despise, loathe, detest, abhor, disfavor, dislike, disapprove, abominate",
            "hold, possess, own, contain, acquire, gain, maintain, believe, bear, beget, occupy, absorb, fill, enjoy",
            "aid, assist, support, encourage, back, wait, on, attend, serve, relieve, succor, benefit, befriend, abet",
            "conceal, cover, mask, cloak, camouflage, screen, shroud, veil",
            "rush, run, speed, race, hasten, urge, accelerate, bustle",
            "damage, harm, injure, wound, distress, afflict, pain",
            "thought, concept, conception, notion, understanding, opinion, plan, view, belief",
            "necessary, vital, critical, indispensable, valuable, essential, significant, primary, principal, considerable, famous, distinguished, notable, well-known",
            "fascinating, engaging, sharp, keen, bright, intelligent, animated, spirited, attractive, inviting, intriguing, provocative, though-provoking, challenging, inspiring, involving, moving, titillating, tantalizing, exciting, entertaining, piquant, lively, racy, spicy, engrossing, absorbing, consuming, gripping, arresting, enthralling, spellbinding, curious, captivating, enchanting, bewitching, appealing",
            "hold, retain, withhold, preserve, maintain, sustain, support",
            "slay, execute, assassinate, murder, destroy, cancel, abolish",
            "indolent, slothful, idle, inactive, sluggish",
            "tiny, small, diminutive, shrimp, runt, miniature, puny, exiguous, dinky, cramped, limited, itsy-bitsy, microscopic, slight, petite, minute",
            "gaze, see, glance, watch, survey, study, seek, search, for, peek, peep, glimpse, stare, contemplate, examine, gape, ogle, scrutinize, inspect, leer, behold, observe, view, witness, perceive, spy, sight, discover, notice, recognize, peer, eye, gawk, peruse, explore",
            "like, admire, esteem, fancy, care, for, cherish, adore, treasure, worship, appreciate, savor",
            "create, originate, invent, beget, form, construct, design, fabricate, manufacture, produce, build, develop, do, effect, execute, compose, perform, accomplish, earn, gain, obtain, acquire, get",
            "label, tag, price, ticket, impress, effect, trace, imprint, stamp, brand, sign, note, heed, notice, designate",
            "prankish, playful, naughty, roguish, waggish, impish, sportive",
            "plod, go, creep, crawl, inch, poke, drag, toddle, shuffle, trot, dawdle, walk, traipse, mosey, jog, plug, trudge, slump, lumber, trail, lag, run, sprint, trip, bound, hotfoot, high-tail, streak, stride, tear, breeze, whisk, rush, dash, dart, bolt, fling, scamper, scurry, skedaddle, scoot, scuttle, scramble, race, chase, hasten, hurry, hump, gallop, lope, accelerate, stir, budge, travel, wander, roam, journey, trek, ride, spin, slip, glide, slide, slither, coast, flow, sail, saunter, hobble, amble, stagger, paddle, slouch, prance, straggle, meander, perambulate, waddle, wobble, pace, swagger, promenade, lunge",
            "temperamental, changeable, short-tempered, glum, morose, sullen, mopish, irritable, testy, peevish, fretful, spiteful, sulky, touchy",
            "clean, orderly, tidy, trim, dapper, natty, smart, elegant, well-organized, super, desirable, spruce, shipshape, well-kept, shapely",
            "fresh, unique, original, unusual, novel, modern, current, recent",
            "feeble, frail, ancient, weak, aged, used, worn, dilapidated, ragged, faded, broken-down, former, old-fashioned, outmoded, passe, veteran, mature, venerable, primitive, traditional, archaic, conventional, customary, stale, musty, obsolete, extinct",
            "portion, share, piece, allotment, section, fraction, fragment",
            "space, area, spot, plot, region, location, situation, position, residence, dwelling, set, site, station, status, state",
            "plot, scheme, design, draw, map, diagram, procedure, arrangement, intention, device, contrivance, method, way, blueprint",
            "well-liked, approved, accepted, favorite, celebrated, common, current",
            "quandary, dilemma, pickle, problem, plight, spot, scrape, jam",
            "place, set, attach, establish, assign, keep, save, set, aside, effect, achieve, do, build",
            "silent, still, soundless, mute, tranquil, peaceful, calm, restful",
            "correct, accurate, factual, true, good, just, honest, upright, lawful, moral, proper, suitable, apt, legal, fair",
            "race, speed, hurry, hasten, sprint, dash, rush, escape, elope, flee",
            "inform, notify, advise, relate, recount, narrate, explain, reveal, disclose, divulge, declare, command, order, bid, enlighten, instruct, insist, teach, train, direct, issue, remark, converse, speak, affirm, suppose, utter, negate, express, verbalize, voice, articulate, pronounce, deliver, convey, impart, assert, state, allege, mutter, mumble, whisper, sigh, exclaim, yell, sing, yelp, snarl, hiss, grunt, snort, roar, bellow, thunder, boom, scream, shriek, screech, squawk, whine, philosophize, stammer, stutter, lisp, drawl, jabber, protest, announce, swear, vow, content, assure, deny, dispute",
            "afraid, frightened, alarmed, terrified, panicked, fearful, unnerved, insecure, timid, shy, skittish, jumpy, disquieted, worried, vexed, troubled, disturbed, horrified, terrorized, shocked, petrified, haunted, timorous, shrinking, tremulous, stupefied, paralyzed, stunned, apprehensive",
            "display, exhibit, present, note, point, to, indicate, explain, reveal, prove, demonstrate, expose",
            "unhurried, gradual, leisurely, late, behind, tedious, slack",
            "cease, halt, stay, pause, discontinue, conclude, end, finish, quit",
            "tale, myth, legend, fable, yarn, account, narrative, chronicle, epic, sage, anecdote, record, memoir",
            "odd, peculiar, unusual, unfamiliar, uncommon, queer, weird, outlandish, curious, unique, exclusive, irregular",
            "hold, catch, seize, grasp, win, capture, acquire, pick, choose, select, prefer, remove, steal, lift, rob, engage, bewitch, purchase, buy, retract, recall, assume, occupy, consume",
            "disclose, reveal, show, expose, uncover, relate, narrate, inform, advise, explain, divulge, declare, command, order, bid, recount, repeat",
            "judge, deem, assume, believe, consider, contemplate, reflect, mediate",
            "distress, anguish, anxiety, worry, wretchedness, pain, danger, peril, disaster, grief, misfortune, difficulty, concern, pains, inconvenience, exertion, effort",
            "accurate, right, proper, precise, exact, valid, genuine, real, actual, trusty, steady, loyal, dependable, sincere, staunch",
            "hideous, frightful, frightening, shocking, horrible, unpleasant, monstrous, terrifying, gross, grisly, ghastly, horrid, unsightly, plain, homely, evil, repulsive, repugnant, gruesome",
            "miserable, uncomfortable, wretched, heart-broken, unfortunate, poor, downhearted, sorrowful, depressed, dejected, melancholy, glum, gloomy, dismal, discouraged, sad",
            "employ, utilize, exhaust, spend, expend, consume, exercise",
            "incorrect, inaccurate, mistaken, erroneous, improper, unsuitable" };

            System.out.print("Enter Word: ");
            String input = br.readLine();
            int lb = 0, ub = words.length - 1, i = -1;
            while(lb < ub) {
                int mid = (lb + ub)/2;
                if(words[mid].compareTo(input) == 0) {
                    i = mid;
                    break;
                } else if(words[mid].compareTo(input) < 0) {
                    lb = mid + 1;
                } else {
                    ub = mid - 1;
                }
            }

            if(!(i == -1)) {
                System.out.println("Meanings: " + meanings[i]);
            } else {
                System.out.println("Word Not Found!");
            }
    }
}