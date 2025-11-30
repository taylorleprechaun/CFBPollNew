# CFBPollNew

### About

This is the code for my computer poll for college football. Originally started in 2018 just to see if I could. This repository started as a rewrite of that original code ([found here](https://github.com/taylorleprechaun/CFBPoll)) and has since been updated and upgraded many times.

This poll uses team statistics and game results to calculate ratings for each team and rank who it thinks is the best team in college football. The rating algoritm gives teams a Score by awarding or deducting points based on some key rating factors. With all the Scores calculated, the teams can be ranked based on whoever's is highest. In the rankings table, the Rating represents each team's Score as a percentage of the #1 team's. If Florida is #1 (in my dreams) with a Score of 50 points, then every team's Score is divided by 50 to calculate their Rating.

Part of the Massey Composite (Steinberg/TSS).

### Recent changes

* 10/5/2025: Summer cleaning Part 4. Pivoted from my in-progress shift to a DB-driven design to entirely using the CFBDataAPI. More work is needed on this still.
* 10/11/2025: Summer cleaning Part 5. Finished the conversion to use the CFBDataAPI as the primary data provider for this computer poll.
* 11/2/2025: Update data output format.

### Rankings (Updated 11/30/2025)

**Week 15 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Indiana | 1.0000 | 12-0 | 0.5367 | 65
2 | Ohio State | 0.9990 | 12-0 | 0.5427 | 61
3 | BYU | 0.9731 | 11-1 | 0.5753 | 26
4 | Georgia | 0.9514 | 11-1 | 0.5539 | 47
5 | Oregon | 0.9458 | 11-1 | 0.5352 | 70
6 | Texas Tech | 0.9369 | 11-1 | 0.5187 | 86
7 | Ole Miss | 0.9364 | 11-1 | 0.5338 | 71
8 | Oklahoma | 0.9357 | 10-2 | 0.5952 | 13
9 | Texas A&M | 0.9330 | 11-1 | 0.5330 | 73
10 | Alabama | 0.9236 | 10-2 | 0.5728 | 28
11 | Miami | 0.9031 | 10-2 | 0.5434 | 60
12 | Utah | 0.8918 | 10-2 | 0.5323 | 75
13 | Vanderbilt | 0.8889 | 10-2 | 0.5310 | 77
14 | Notre Dame | 0.8883 | 10-2 | 0.5437 | 59
15 | North Texas | 0.8869 | 11-1 | 0.5083 | 95
16 | Virginia | 0.8795 | 10-2 | 0.5186 | 87
17 | James Madison | 0.8723 | 11-1 | 0.4936 | 108
18 | USC | 0.8679 | 9-3 | 0.5646 | 35
19 | Michigan | 0.8666 | 9-3 | 0.5643 | 36
20 | Arizona | 0.8578 | 9-3 | 0.5450 | 58
21 | Texas | 0.8544 | 9-3 | 0.5459 | 54
22 | Navy | 0.8432 | 9-2 | 0.5358 | 68
23 | Tulane | 0.8318 | 10-2 | 0.5072 | 98
24 | Illinois | 0.8286 | 8-4 | 0.5790 | 25
25 | Arizona State | 0.8250 | 8-4 | 0.5793 | 22

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2025/2025-Week%2015.md)

#### Observations and Notes (Updated 11/30/2025)

* Going into the conference championship games there's a lot of teams vying for the at-large bids. In past years I've done something where I make a matrix of winners/losers in the conference championship games and use that to determine really rough odds of who is in/out and how they get there. When I rewrote my code I hadn't really thought about how I'd handle this tbh. I want to do it again but not sure if I will get it out in time. Maybe if I get bored during the week. We'll see.

#### Predictions (Updated 9/11/2025)

I've decided not to generate game predictions this season unless I get a huge amount of sudden free time. I didn't have the time in the offseason that I wanted to to make the changes I had planned and won't have time to make them for a while due to work and life stuff. Around the playoffs I'll probably run everything through my current algorithm just to do something, but that's about all you can expect.

2024 Season Results:
* Winner: 510 - 238 (68.2%)
* ATS: 364 - 394 (48.0%)
* O/U: 374 - 384 (49.3%)

2023 Season Results:
* Winner: 507 - 232 (68.6%)
* ATS: 365 - 374 (49.4%)
* O/U: 366 - 373 (49.5%)

2022 Season Results:
* Winner: 485 - 240 (66.9%)
* ATS: 341 - 383 (47.1%)
* O/U: 372 - 352 (51.4%)

### TODO List (Updated 11/2/2025)

1. Finish data source conversion. I pivoted from my switch to a DB-driven design to now using the CFBDataAPI. I did not convert the code which handles early season rating adjustments nor any of the prediction code. Which leads directly into points #2 and #3, where I wanted to make changes to those anyway.

2. Improve early season ratings (recruiting info, returning production stats, etc.). Look into the way Strength of Schedule is calculated and weighted in the early season to make sure it is not giving too much credit to the previous season's data.

3. Improve prediction algorithm. The goal of this is: Winner >70%, ATS >50%, OU >50%, and minimizing the RMSE of my score predictions. No idea how realistic these numbers are. I have [this site](https://www.thepredictiontracker.com/ncaaresults.php) bookmarked that someone mentioned to me on r/CFB with the results of a bunch of predictive algorithms that I will use to benchmark my performance.

4. Improve the console app for running the poll to make it a little friendlier to use. I may also skip this and go directly to #5.

5. Build a basic UI for the poll. The UI would give me all the functionality from my current console app plus more. Depending on how this goes I may look into getting a real website to host this instead of just using GitHub out of convenience.

6. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2024.

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.
I'm probably going to have to split the CFP era into 4 and 12 team sections but that's a problem for future me. As of right now I'm not going to split into 4 vs 12 but maybe in the future I will.

*New additions for the 2024 season!*

* No one cracked 40 points so no one is making it into the BOAT section for 2024. Oregon came closest at 39.962 and Ohio State was a little behind at 39.802
* Kent State repeats this year as worst team in FBS. They finished with a rating of 15.735, placing them at 9th worst in the Playoff Era

**The top 5 Best of all Time (pre-CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2001 | Miami FL | 42.309 | 12-0
2 | 2009 | Alabama | 41.756 | 14-0
3 | 2010 | Auburn | 41.464 | 14-0
4 | 2005 | Texas | 41.291 | 13-0
5 | 2000 | Oklahoma | 41.246 | 13-0

**The top 5 Best of all Time (CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2018 | Clemson | 42.445 | 15-0
2 | 2019 | LSU | 42.374 | 15-0
3 | 2023 | Michigan | 42.244 | 15-0
4 | 2022 | Georgia | 42.124 | 15-0
5 | 2015 | Alabama | 41.615 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
