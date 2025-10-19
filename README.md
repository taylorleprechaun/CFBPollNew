# CFBPollNew

### About

This is the code for my computer poll for college football. Originally started in 2018 just to see if I could. This repository started as a rewrite of that original code ([found here](https://github.com/taylorleprechaun/CFBPoll)) and has since been updated and upgraded many times.

This poll uses team statistics and game results to calculate ratings for each team and rank who it thinks is the best team in college football. The rating algoritm gives teams a Score by awarding or deducting points based on some key rating factors. With all the Scores calculated, the teams can be ranked based on whoever's is highest. In the rankings table, the Rating represents each team's Score as a percentage of the #1 team's. If Florida is #1 (in my dreams) with a Score of 50 points, then every team's Score is divided by 50 to calculate their Rating.

Part of the Massey Composite (Steinberg/TSS).

### Recent changes

* 10/5/2025: Summer cleaning Part 4. Pivoted from my in-progress shift to a DB-driven design to entirely using the CFBDataAPI. More work is needed on this still.
* 10/11/2025: Summer cleaning Part 5. Finished the conversion to use the CFBDataAPI as the primary data provider for this computer poll.

### Rankings (Updated 10/19/2025)

**Week 9 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Indiana | 1.0000 | 7-0 | 0.6297 | 16
2 | Ohio State | 0.9779 | 7-0 | 0.6046 | 33
3 | BYU | 0.9369 | 7-0 | 0.5518 | 76
4 | Louisville | 0.9321 | 5-1 | 0.6686 | 4
5 | Texas A&M | 0.9276 | 7-0 | 0.5469 | 82
6 | Miami | 0.9219 | 5-1 | 0.6541 | 8
7 | Georgia Tech | 0.9189 | 7-0 | 0.5383 | 88
8 | Alabama | 0.9085 | 6-1 | 0.6153 | 25
9 | Georgia | 0.9025 | 6-1 | 0.6171 | 24
10 | Texas Tech | 0.8731 | 6-1 | 0.5612 | 65
11 | Virginia | 0.8725 | 6-1 | 0.5706 | 59
12 | Illinois | 0.8630 | 5-2 | 0.6652 | 5
13 | Ole Miss | 0.8626 | 6-1 | 0.5646 | 62
14 | Vanderbilt | 0.8598 | 6-1 | 0.5499 | 78
15 | Cincinnati | 0.8577 | 6-1 | 0.5524 | 75
16 | Oklahoma | 0.8508 | 6-1 | 0.5455 | 83
17 | Oregon | 0.8476 | 6-1 | 0.5262 | 93
18 | South Florida | 0.8457 | 6-1 | 0.5787 | 49
19 | Navy | 0.8369 | 6-0 | 0.4689 | 124
20 | Arizona State | 0.8263 | 5-2 | 0.6143 | 26
21 | Michigan | 0.8242 | 5-2 | 0.6025 | 36
22 | Notre Dame | 0.8221 | 5-2 | 0.6225 | 22
23 | Utah | 0.8214 | 5-2 | 0.6043 | 34
24 | Missouri | 0.8213 | 6-1 | 0.5000 | 112
25 | LSU | 0.8209 | 5-2 | 0.6068 | 31

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2025/2025-Week%2009.md)

#### Observations and Notes (Updated 10/12/2025)

* This week is the first run with my new changes using the CFBDataAPI for everything. I ran the old version of my rankings again just to be sure nothing is totally messed up. The only differences are because the numbers I use now are slightly 
different (more precision) causing a few teams flip positions (ex: James Madison and FSU switch between #44 and #45 on the new code). Really happy I made this change because now running this is much easier now that I don't have to use my script I had to refresh the Excel files I was pulling from sports-reference.

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

### TODO List (Updated 10/11/2025)

1. Finish data source conversion. I pivoted from my switch to a DB-driven design to now using the CFBDataAPI. I did not convert the code which handles early season rating adjustments nor any of the prediction code. Which leads directly into points #2 and #3, where I wanted to make changes to those anyway.

2. Improve early season ratings (recruiting info, returning production stats, etc.). Look into the way Strength of Schedule is calculated and weighted in the early season to make sure it is not giving too much credit to the previous season's data.

3. Improve prediction algorithm. The goal of this is: Winner >70%, ATS >50%, OU >50%, and minimizing the RMSE of my score predictions. No idea how realistic these numbers are. I have [this site](https://www.thepredictiontracker.com/ncaaresults.php) bookmarked that someone mentioned to me on r/CFB with the results of a bunch of predictive algorithms that I will use to benchmark my performance.

4. Improve the console app for running the poll to make it a little friendlier to use. I may also skip this and go directly to #5.

5. Build a basic UI for the poll. The UI would give me all the functionality from my current console app plus more. Depending on how this goes I may look into getting a real website to host this instead of just using GitHub out of convenience.

6. Add more data print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

7. ????

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
